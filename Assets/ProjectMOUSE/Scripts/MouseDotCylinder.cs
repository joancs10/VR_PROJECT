using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDotCylinder : MonoBehaviour
{
    [SerializeField]
    private Camera ExternalCamera;  // La càmera des de la qual es veurà el cilindre
    [SerializeField]
    private GameObject m_targetObject;  // Objecte que es mou amb el raig del ratolí
    [SerializeField]
    private LayerMask raycastLayerMask;  // Mask per limitar les superfícies amb les que interactua el raig

    [SerializeField]
    private float targetSize = 0.5f; // Tamany desitjat del cilindre en unitats de l'escala de la càmera

    private bool isHitObjectActive = true; // Indica si el "hit" està activat o desactivat
    private Collider m_targetCollider; // Referència al col·lisionador de l'objecte que es mou

    void Start()
    {
        // Obtenim el col·lisionador de l'objecte al començar
        m_targetCollider = m_targetObject.GetComponent<Collider>();
    }

    void Update()
    {
        // Comprovem si es prem la tecla F per alternar l'estat de 'isHitObjectActive'
        if (Input.GetKeyDown(KeyCode.F))
        {
            isHitObjectActive = !isHitObjectActive;

            // Activem o desactivem la col·lisió segons l'estat
            m_targetCollider.enabled = isHitObjectActive;
        }

        // Si el "hit" està activat, detectem el raig
        if (isHitObjectActive)
        {
            // Llançar un raig des de la posició del ratolí
            Ray ray = ExternalCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
            {
                // Obtenir l'objecte amb el qual ha impactat el raig
                GameObject hitObject = hit.collider.gameObject;
                m_targetObject.transform.position = hit.point; // M
            }
        }
    }
}