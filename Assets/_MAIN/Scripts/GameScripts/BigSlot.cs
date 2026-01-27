using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[SerializeField]
public struct Characters
{
    public Sprite portait;
    [TextArea]
    public string text;
}
public class BigSlot : Slot
{
    [SerializeField] Characters characters;
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }
}
