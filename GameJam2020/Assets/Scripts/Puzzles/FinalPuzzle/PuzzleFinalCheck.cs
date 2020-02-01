using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFinalCheck : MonoBehaviour
{
    private bool puzzleDone = false;
    public int lightOnCounter = 0;
    public int maxLights = 0;

    // Update is called once per frame
    void Update()
    {
        if (lightOnCounter == maxLights)
        {
            puzzleDone = true;
            Debug.Log(puzzleDone);
        }
    }
}
