using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public struct Characters
{
    public Sprite portait;
    [TextArea]
    public string text;
}
public class BigSlot : Slot
{
    [SerializeField] public Characters[] characters;
    [SerializeField] public DragableElement characterPrefab;
    public List<DragableElement> spawned = new();
    private void Start()
    {
        GameManager.Instance.OnDayChange += OnNextDay;
        OnNextDay(GameManager.Instance.currDay);
    }
    public void OnNextDay(int _)
    {
        ClearAll();
        for (int i = 0; i < characters.Length; i++)
        {
            DragableElement inst = Instantiate(characterPrefab);
            inst.transform.SetParent(transform, false);
            inst.img.sprite = characters[i].portait;
            inst.text.text = characters[i].text;
            spawned.Add(inst);
        }
    }

    public void ClearAll()
    {
        foreach (var character in spawned)
        {
            Destroy(character.gameObject);
        }
        spawned.Clear();
    }
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnDayChange -= OnNextDay;
    }
}
