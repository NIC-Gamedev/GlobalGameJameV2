using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void SetText(string value)
    {
        text.text = value;
    }
}


public class TooltipManager
{
    [SerializeField] Tooltip prefab;
    Tooltip current;

    public void Show(string text, Vector2 screenPos)
    {
        if (!current)
            current = Object.Instantiate(prefab, screenPos,Quaternion.identity);

        current.SetText(text);
        current.transform.position = screenPos;
        current.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (current)
            current.gameObject.SetActive(false);
    }
}
