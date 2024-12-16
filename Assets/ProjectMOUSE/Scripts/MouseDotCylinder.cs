using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDotCylinder : MonoBehaviour
{
    [SerializeField]
    private Camera ExternalCamera;
    [SerializeField]
    private GameObject m_targetObject;
    [SerializeField]
    private LayerMask raycastLayerMask;
    
     void Update()
    {

        // Cast a ray from the mouse position
        Ray ray = ExternalCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
        {
            // Check if the ray hits any object with a collider
            GameObject hitObject = hit.collider.gameObject;
            m_targetObject.transform.position = hit.point;

        }
    }
}