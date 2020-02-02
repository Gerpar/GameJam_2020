using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFinalCheck : MonoBehaviour
{
    public bool puzzleDone = false;
    [SerializeField] PuzzleSolvedLights puzzleSolvedLights;
    public int lightOnCounter = 0;
    public int maxLights = 0;

    private void Start()
    {
        if(puzzleSolvedLights == null)
            puzzleSolvedLights = GetComponent<PuzzleSolvedLights>();
    }
    // Update is called once per frame
    void Update()
    {
        if (lightOnCounter == maxLights)
        {
            puzzleDone = true;
            puzzleSolvedLights.IsPuzzleSolved = true;
            Debug.Log(puzzleDone);
        }
    }
}
