using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTemp : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject show;
    public void OnPointerEnter(PointerEventData eventData)
    {
        show.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        show.SetActive(false);
    }

   
}
