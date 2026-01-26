using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragableElement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public Transform parentAfterDrag;
    public Transform parentBefDrag;
    private Canvas canvas;
    private Vector2 sizeBef;
    public Vector2 sizeAfter;
    public Vector2 moveOffset;

    public CanvasGroup canvasGroup,mainGroup;

    private RectTransform tempRect;

    private Tween dragTween;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        sizeBef = rectTransform.sizeDelta;
        canvas = rectTransform.GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentBefDrag = transform.parent;
        parentAfterDrag = transform.parent;
        int indexWas = transform.GetSiblingIndex();
        rectTransform.SetParent(canvas.transform, worldPositionStays: false);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0;
        dragTween = rectTransform.DOSizeDelta(sizeAfter, 0.2f);
        tempRect = new GameObject($"Temp{name}",typeof(RectTransform)).GetComponent<RectTransform>();
        tempRect.SetParent(parentBefDrag);
        tempRect.SetSiblingIndex(indexWas);
        mainGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        rectTransform.localPosition = localPoint + moveOffset;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.SetParent(parentAfterDrag, worldPositionStays: false);

        if(parentAfterDrag.TryGetComponent(out BigSlot bigSlot))
        {
            canvasGroup.alpha = 1;
            dragTween.Kill();
            rectTransform.sizeDelta = sizeBef;
            int indexWas = tempRect.GetSiblingIndex();
            rectTransform.SetSiblingIndex(indexWas);
        }
        mainGroup.blocksRaycasts = true;
        Destroy(tempRect.gameObject);
    }
}
