using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SizeTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text1;
    public int newFontSize = 20;
    public int startFontSize = 14;

    // Use this for initialization

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(text1.fontSize);
        text1.fontSize = newFontSize;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text1.fontSize = startFontSize;
    }
}
