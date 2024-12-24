using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{

    public GameObject Puzzle1, Puzzle2, Puzzle3, Puzzle4, Puzzle5;
    public Light LightComponent, WallLight1;

    // Start is called before the first frame update
    void Start()
    {
        StartPuzzle1();


        if (LightComponent != null)
        {
            LightComponent.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPuzzle1()
    {
        Puzzle1.SetActive(true);
        Puzzle2.SetActive(false);
        Puzzle3.SetActive(false);
        Puzzle4.SetActive(false);
        Puzzle5.SetActive(false);
        if (WallLight1 != null)
        {
            WallLight1.enabled = false; // Desactiva la llum
        }
    }
    public void StartPuzzle2()
    {
        Puzzle1.SetActive(false);
        Puzzle2.SetActive(true);
        Puzzle3.SetActive(false);
        Puzzle4.SetActive(false);
        Puzzle5.SetActive(false);
    }
    public void StartPuzzle3()
    {
        Puzzle1.SetActive(false);
        Puzzle2.SetActive(false);
        Puzzle3.SetActive(true);
        Puzzle4.SetActive(false);
        Puzzle5.SetActive(false);
    }
    public void StartPuzzle4()
    {
        Puzzle1.SetActive(false);
        Puzzle2.SetActive(false);
        Puzzle3.SetActive(false);
        Puzzle4.SetActive(true);
        Puzzle5.SetActive(false);
    }

    public void WallLightActivation()
    {
        if (WallLight1 != null)
        {
            WallLight1.enabled = true; // Activa la llum
        }
    }
    public void StartPuzzle5()
    {
        Puzzle1.SetActive(false);
        Puzzle2.SetActive(false);
        Puzzle3.SetActive(false);
        Puzzle4.SetActive(false);
        Puzzle5.SetActive(true);
    }

}
