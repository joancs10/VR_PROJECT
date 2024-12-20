using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDotCylinder : MonoBehaviour
{
    [SerializeField]
    private Camera ExternalCamera;  // La c�mera des de la qual es veur� el cilindre
    [SerializeField]
    private GameObject m_targetObject;  // Objecte que es mou amb el raig del ratol�
    [SerializeField]
    private LayerMask raycastLayerMask;  // Mask per limitar les superf�cies amb les que interactua el raig

    [SerializeField]
    private float targetSize = 0.05f; // Tamany desitjat del cilindre en unitats de l'escala de la c�mera

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

            // Calcular la dist�ncia entre la c�mera i el punt d'impacte
            float distance = Vector3.Distance(ExternalCamera.transform.position, hit.point);

            // Ajustar l'escala del cilindre perqu� sembli de la mateixa mida des de la c�mera
            // Utilitzem la dist�ncia per determinar la mida
            m_targetObject.transform.localScale = new Vector3(targetSize * distance, targetSize * distance, targetSize * distance);
        }
    }
}