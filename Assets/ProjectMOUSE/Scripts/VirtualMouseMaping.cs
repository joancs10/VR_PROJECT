using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouseMaping : MonoBehaviour
{
    [SerializeField]
    private Camera ExternalCamera;  // La c�mera des de la qual es veur� el cilindre
    [SerializeField]
    private GameObject m_targetObject;  // Objecte que es mou amb el raig del ratol�
    [SerializeField]
    private LayerMask raycastLayerMask;  // Mask per limitar les superf�cies amb les que interactua el raig

    void Update()
    {
        // Llan�ar un raig des de la posici� del ratol�
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
