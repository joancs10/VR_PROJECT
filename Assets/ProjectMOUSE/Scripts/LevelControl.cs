using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{

    public GameObject Puzzle1, Puzzle2;
    public Light LightComponent;

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
    }
    public void StartPuzzle2()
    {
        Puzzle1.SetActive(false);
        Puzzle2.SetActive(true);
    }


}
