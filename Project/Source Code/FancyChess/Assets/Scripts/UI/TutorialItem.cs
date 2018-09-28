using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialItem : MonoBehaviour , IPointerEnterHandler
{

    
    public string description;

    public void OnPointerEnter(PointerEventData p)
    {
        TutorialControler.instance.handleMessage(description);
    }
}
