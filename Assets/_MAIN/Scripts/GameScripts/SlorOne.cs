using UnityEngine;
using UnityEngine.EventSystems;

public class SlorOne : Slot
{
    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0)
            return;
        base.OnDrop(eventData);
    }
}
