using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouseMaping : MonoBehaviour
{
    [SerializeField]
    private Camera ExternalCamera;  // La càmera des de la qual es veurà el cilindre
    [SerializeField]
    private GameObject m_targetObject;  // Objecte que es mou amb el raig del ratolí
    [SerializeField]
    private LayerMask raycastLayerMask;  // Mask per limitar les superfícies amb les que interactua el raig

    void Update()
    {
        // Llançar un raig des de la posició del ratolí
        Ray ray = ExternalCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
        {
            // Obtenir l'objecte amb el qual ha impactat el raig
            GameObject hitObject = hit.collider.gameObject;
            m_targetObject.transform.position = hit.point; // Movem el cilindre al punt d'impacte
        }
    }
}
