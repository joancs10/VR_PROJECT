using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderWall : MonoBehaviour
{
    [SerializeField]
    private string m_tag;

    public Material RedMaterial;
    public Material YellowMaterial;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == m_tag)
        {
            gameObject.GetComponent<Renderer>().material = YellowMaterial;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == m_tag)
        {
            gameObject.GetComponent<Renderer>().material = RedMaterial;
        }
    }


}
