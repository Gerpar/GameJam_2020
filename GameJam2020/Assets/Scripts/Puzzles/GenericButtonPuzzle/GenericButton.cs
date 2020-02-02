using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericButton : MonoBehaviour
{
    public PuzzleFinalCheck puzzleCheck;

    public bool slotNecessary = false;
    public GameObject puzzlePiece;
    private bool slotFilled = false;

    public List<GameObject> lights;

    public int lightsUnderControl = 0;
    public List<int> lightsToToggle;

    //public List<GameObject> wiresFromButton;

    private bool buttonPressed = false;

    private void Update()
    {
        slotFilled = puzzlePiece.GetComponent<TriangleToHole>().triangleInHole;
    }

    private void OnMouseDown()
    {
        if (slotNecessary == false)
            ToggleLightSection(lightsUnderControl, lightsToToggle);
        else if (slotNecessary == true)
        {
            if (slotFilled)
                ToggleLightSection(lightsUnderControl, lightsToToggle);
        }

        //if (buttonPressed == true)
        //    buttonPressed = false;
        //else
        //    buttonPressed = true;

        //if(buttonPressed)
        //{
        //    for(int i = 0; i < wiresFromButton.Count; i++)
        //    {
        //        if (wiresFromButton[i].GetComponent<MeshRenderer>().enabled == false)
        //            wiresFromButton[i].GetComponent<MeshRenderer>().enabled = true;
        //        else
        //            wiresFromButton[i].GetComponent<MeshRenderer>().enabled = false;
        //    }
        //}
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
