using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericButton : MonoBehaviour
{
    public PuzzleFinalCheck puzzleCheck;

    public List<GameObject> lights;

    public int lightsUnderControl = 0;
    public List<int> lightsToToggle;

    private void OnMouseDown()
    {
        ToggleLightSection(lightsUnderControl, lightsToToggle);
    }

    public void ToggleLightSection(int numLights, List<int> lightsToToggle)
    {
        for (int i = 0; i < numLights; i++)
        {
            ToggleLight(lights[lightsToToggle[i]]);
        }
    }

    public void ToggleLight(GameObject light)
    {
        if (light.GetComponent<Light>().enabled == false)
        {
            light.GetComponent<Light>().enabled = true;
            puzzleCheck.lightOnCounter++;
        }
        else
        {
            light.GetComponent<Light>().enabled = false;
            puzzleCheck.lightOnCounter--;
        }
    }
}
