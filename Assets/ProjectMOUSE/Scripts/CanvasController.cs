using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject objectToActivate; // Referencia al GameObject que queremos activar
    public GameObject canvasStart; // Referencia al GameObject que queremos activar
    public GameObject canvasLoading; // Referencia al GameObject que queremos activar
    public GameObject canvasWin; // Referencia al GameObject que queremos activar
    public GameObject canvasFailed; // Referencia al GameObject que queremos activar
    private Vector3 lastMousePosition;
    private bool isActivated = false;
    public AudioSource maze;
    private bool hasPlayed = false;

    void Start()
    {
        // Inicialmente, aseguramos que el objeto está desactivado
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
            canvasLoading.SetActive(false);
            canvasWin.SetActive(false);
            canvasFailed.SetActive(false);
        }

        // Guardamos la posición inicial del ratón
        lastMousePosition = Input.mousePosition;
        
    }

    void Update()
    {
        // Comprobamos si el ratón se ha movido
        if (Input.mousePosition != lastMousePosition && !hasPlayed)
        {
            // Si el ratón se ha movido y el objeto no está activado
            if (!isActivated && objectToActivate != null)
            {
                StartCoroutine(loadingScreen());

            }

            if (maze != null && !maze.isPlaying)
            {
                maze.Play(); // Reproduce el audio
                hasPlayed = true; 
            }

            // Actualizamos la última posición del ratón
            lastMousePosition = Input.mousePosition;
            
        }

    }

    IEnumerator loadingScreen()
    {
            canvasStart.SetActive(false); // Activamos el objeto
            canvasLoading.SetActive(true); // Activamos el objeto
            yield return new WaitForSeconds(4f);
            canvasLoading.SetActive(false); // Activamos el objeto
            objectToActivate.SetActive(true); // Activamos el objeto
            isActivated = true; // Marcamos que el objeto ya está activado
    }
}
