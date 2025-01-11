using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject canvasWin; // Referencia al GameObject que queremos activar
    public GameObject canvasFailed;
    public LayerMask lightLayer, lightLayerB; // Layer mask for the controllable lights
    public LevelControl LevelControlScript;
    
    void Start()
    {
        // Find all light components in the scene
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            if (((1 << light.gameObject.layer) & lightLayerB) != 0)
            {
                light.enabled = false; // Turn off light if it's in the specified layer
            }
        }
    }

    // Function to turn off lights in the specified layer
    public void TurnOffLightsByLayer()
    {
        LevelControlScript.disabledLevels();
        canvasFailed.SetActive(true);
        // Find all light components in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through all lights and check if they belong to the specified layer
        foreach (Light light in lights)
        {
            if (((1 << light.gameObject.layer) & lightLayer) != 0)
            {
                light.enabled = false; // Turn off light if it's in the specified layer
            }
        }
        foreach (Light light in lights)
        {
            if (((1 << light.gameObject.layer) & lightLayerB) != 0)
            {
                light.enabled = true; // Turn off light if it's in the specified layer
            }
        }

        // Call the TurnOnLights function after 3 seconds
        StartCoroutine(TurnOnLightsAfterDelay(3f)); // 3 seconds delay
    }

    // Coroutine to turn on the lights in the specified layer after a delay
    private IEnumerator TurnOnLightsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        canvasFailed.SetActive(false);   
        LevelControlScript.StartPuzzle1();

        // Find all light components in the scene
        Light[] lights = FindObjectsOfType<Light>();

        // Loop through all lights and check if they belong to the specified layer
        foreach (Light light in lights)
        {
            if (((1 << light.gameObject.layer) & lightLayer) != 0)
            {
                light.enabled = true; // Turn the light back on if it's in the specified layer
            }
        }
        foreach (Light light in lights)
        {
            if (((1 << light.gameObject.layer) & lightLayerB) != 0)
            {
                light.enabled = false; // Turn off light if it's in the specified layer
            }
        }
    }
}
