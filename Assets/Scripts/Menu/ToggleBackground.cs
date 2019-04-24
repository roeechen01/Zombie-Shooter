using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleBackground : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image background;

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(1f, 1f, 1f, 0.8f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(1f, 1f, 1f, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
    }
}
