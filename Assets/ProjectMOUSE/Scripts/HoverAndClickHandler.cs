using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverAndClickHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Referència al TextMeshProUGUI per mostrar el text
    public TextMeshProUGUI winText;

    private void Start()
    {
        // Assegura't que el TextMeshProUGUI estigui assignat
        if (winText == null)
        {
            Debug.LogWarning("TextMeshPro reference is not assigned.");
        }
    }

    // Quan el ratolí entra en el component
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Mostrar el text "AGAIN" en el TextMeshProUGUI
        if (winText != null)
        {
            winText.text = "AGAIN";  // El text que apareixerà
            winText.gameObject.SetActive(true);  // Fer visible el text
        }
    }

    // Quan el ratolí surt del component
    public void OnPointerExit(PointerEventData eventData)
    {
        // Amagar el text
        if (winText != null)
        {
            winText.gameObject.SetActive(false);  // Amagar el text
        }
    }
}