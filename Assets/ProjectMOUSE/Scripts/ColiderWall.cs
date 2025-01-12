using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderWall : MonoBehaviour
{
    [SerializeField]
    private string m_tag1; // Primer tag (Walls)
    [SerializeField]
    private string m_tag2; // Segon tag
    [SerializeField]
    private string m_tag3; // Tercer tag
    [SerializeField]
    private string m_tag4; // Quart tag
    [SerializeField]
    private string m_tag5; // Cinqu� tag
    [SerializeField]
    private string m_tag6; // Sis� tag (Llums paret)
    [SerializeField]
    private string m_tag7; // Set� tag 

    public Material RedMaterial;
    public Material YellowMaterial;

    public LevelControl LevelControlScript;
    public LightControl LightControlScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(m_tag1))
        {
            // Si l'objecte t� el primer tag, canviem el material a Yellow
            gameObject.GetComponent<Renderer>().material = YellowMaterial;
            LevelControlScript.StartPuzzle1();  // Executa l'acci� corresponent al primer tag
            LightControlScript.TurnOffLightsByLayer();
        }
        else if (other.transform.CompareTag(m_tag2))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.StartPuzzle2();  // Executa una acci� diferent per al segon tag
        }
        else if (other.transform.CompareTag(m_tag3))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.StartPuzzle3();  // Executa una acci� diferent per al segon tag
        }
        else if (other.transform.CompareTag(m_tag4))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.StartPuzzle4();  // Executa una acci� diferent per al segon tag
        }
        else if (other.transform.CompareTag(m_tag5))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.StartPuzzle5();  // Executa una acci� diferent per al segon tag
        }
        else if (other.transform.CompareTag(m_tag6))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.WallLightActivation();  // Executa una acci� diferent per al segon tag
        }
        else if (other.transform.CompareTag(m_tag7))
        {
            // Si l'objecte t� el segon tag, realitzem una altra acci� (exemple de canvi de color)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
            LevelControlScript.StartPuzzle1();  // Executa una acci� diferent per al segon tag
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(m_tag1))
        {
            // Quan un objecte amb m_tag1 surt, restableix el material a Red
            gameObject.GetComponent<Renderer>().material = RedMaterial;
        }
        else if (other.transform.CompareTag(m_tag2))
        {
            // Quan un objecte amb m_tag2 surt, restableix el material a Red (o una altra acci�)
            gameObject.GetComponent<Renderer>().material = RedMaterial;
        }
    }
}
