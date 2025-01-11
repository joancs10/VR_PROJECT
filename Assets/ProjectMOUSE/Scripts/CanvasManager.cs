using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] canvases;   // Array para almacenar los 5 canvases

    private bool isCanvasActive = false;  // Control para saber si los canvases están activos

    void Start()
    {
        // Inicialmente, desactivamos todos los canvases
        foreach (GameObject canvas in canvases)
        {
            //canvas.SetActive(false);
        }
    }

    void Update()
    {
        // Ejemplo: Activamos los canvases al presionar una tecla, por ejemplo "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCanvas();  // Cambia el estado de los canvases (activos/desactivados)
        }
    }

    // Función para activar o desactivar todos los canvases
    public void ToggleCanvas()
    {
        // Si los canvases están desactivados, los activamos
        if (!isCanvasActive)
        {
            foreach (GameObject canvas in canvases)
            {
              //  canvas.SetActive(true);
            }
        }
        else
        {
            // Si ya están activos, los desactivamos
            foreach (GameObject canvas in canvases)
            {
            //    canvas.SetActive(false);
            }
        }

        // Cambiamos el estado
        isCanvasActive = !isCanvasActive;
    }

    // Función para activar un canvas específico
    public void ActivateCanvas(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
           // canvases[index].SetActive(true);
        }
    }

    // Función para desactivar un canvas específico
    public void DeactivateCanvas(int index)
    {
        if (index >= 0 && index < canvases.Length)
        {
          //  canvases[index].SetActive(false);
        }
    }
}
