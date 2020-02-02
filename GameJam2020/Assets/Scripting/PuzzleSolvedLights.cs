using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolvedLights : MonoBehaviour
{
    [SerializeField] List<Light> lights;
    [SerializeField] Color lightColour;
    private bool puzzleSolved;

    public bool IsPuzzleSolved
    {
        get
        {
            return puzzleSolved;
        }
        set
        {
            if (puzzleSolved == false)
            {
                ActivateLights();
                puzzleSolved = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].enabled = false;
            lights[i].color = lightColour;
        }
            puzzleSolved = false;
    }

    void ActivateLights()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].enabled = true;
        }
    }
    
}
