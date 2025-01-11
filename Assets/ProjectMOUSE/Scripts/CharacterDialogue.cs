using System.Collections;
using UnityEngine;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{
    public GameObject character3D;         // El personatge 3D (la rata) que apareixerà i desapareixerà
    public GameObject dialoguePanel;       // El Panel que conté el Text
    public TMP_Text dialogueText;          // El component Text dins del Panel

    public string[] dialogueLines;         // L'array de frases que el personatge dirà
    public float timeBetweenLines = 3f;    // Temps entre cada frase
    public float moveForwardSpeed = 0.01f;  // Velocitat amb la qual el personatge es mou cap endavant (més lent)
    public float maxDistanceForward = 5f;  // Distància màxima que el personatge es mourà cap endavant
    public float disappearDelay = 5f;      // Temps després del qual el personatge desapareix (en segons)

    private Vector3 initialPosition;       // Posició inicial del personatge

    void Start()
    {
        // Inicialment, amaga el personatge 3D, el panell de diàleg i el text
        character3D.SetActive(false);
        dialoguePanel.SetActive(false);  // El panell també comença amagat
        dialogueText.text = "";

        // Guardem la posició inicial del personatge
        initialPosition = character3D.transform.position;

        // Inicia la corutina per esperar 10 segons abans de mostrar el Canvas
        StartCoroutine(ShowCanvasAfterDelay(10f));  // Aquí esperem 10 segons abans de mostrar el Canvas
    }

    // Corutina per mostrar el Canvas després d'un retard de 10 segons
    IEnumerator ShowCanvasAfterDelay(float delayTime)
    {
        // Espera el temps especificat (10 segons)
        yield return new WaitForSeconds(delayTime);

        // Mostra el Canvas
        dialoguePanel.SetActive(true);

        // Inicia el diàleg
        StartCoroutine(StartDialogue());
    }

    // Corutina per iniciar el diàleg i moure el personatge
    IEnumerator StartDialogue()
    {
        // Mostra el personatge 3D
        character3D.SetActive(true);

        // Mostra les frases una per una
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            // Assigna la frase al Text
            dialogueText.text = dialogueLines[i];  

            // Si estem a la darrera frase, mou el personatge endavant i desapareix
            if (i == dialogueLines.Length - 1)
            {
                // Mou el personatge cap endavant
                yield return StartCoroutine(MoveCharacterForward());

                // Espera 5 segons abans de desaparèixer el personatge
                yield return new WaitForSeconds(disappearDelay);

                // Desactiva el personatge després dels 5 segons
                character3D.SetActive(false);
            }

            // Espera el temps definit abans de passar a la següent frase
            yield return new WaitForSeconds(timeBetweenLines);
        }

        // Desactiva el panel (i el text) al final del diàleg
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    // Corutina per moure el personatge cap endavant de forma suau
    IEnumerator MoveCharacterForward()
    {
        float distanceMoved = 0f;

        // Fins que el personatge no hagi arribat a la distància màxima, continuem movent-lo
        while (distanceMoved < maxDistanceForward)
        {
            // Move el personatge a la seva posició original més un desplaçament gradual cap endavant
            float moveStep = moveForwardSpeed * Time.deltaTime;
            character3D.transform.position = Vector3.Lerp(
                character3D.transform.position, 
                initialPosition + new Vector3(0, 0, maxDistanceForward), // Moviment cap endavant en Z
                moveStep);

            distanceMoved += moveStep;

            yield return null;
        }

        // Assegurem-nos que el personatge arribi exactament a la distància màxima
        character3D.transform.position = initialPosition + new Vector3(0, 0, maxDistanceForward);
    }
}
