using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        // Obtenim la rotació de la càmera
        Vector3 cameraEulerAngles = playerCamera.transform.eulerAngles;

        // Limitem la rotació a l'eix Y (si no vols que giri cap amunt o avall)
        transform.rotation = Quaternion.Euler(0, cameraEulerAngles.y, 0);
    }
}
