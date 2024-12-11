using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverAndClickHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image myImage;

    private void Start()
    {
        myImage = gameObject.GetComponent<Image>();
        
        if(myImage == null)
        {
            Debug.LogWarning("image is null");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myImage.color = Color.red;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myImage.color = Color.white;

    }
    
}
