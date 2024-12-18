using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderWall : MonoBehaviour
{
    [SerializeField]
    private string m_tag;

    public Material RedMaterial;
    public Material YellowMaterial;

    public LevelControl LevelControlScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == m_tag)
        {
            gameObject.GetComponent<Renderer>().material = YellowMaterial;
            LevelControlScript.StartPuzzle2();
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
