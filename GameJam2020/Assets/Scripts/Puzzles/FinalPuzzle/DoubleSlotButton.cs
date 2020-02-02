using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlotButton : MonoBehaviour
{
    public PuzzleFinalCheck puzzleCheck;

    public GameObject firstSlot;
    public GameObject secondSlot;

    public List<GameObject> lights;

    public int lightsInFirst = 0;
    public List<int> firstLightsToToggle;
    public List<GameObject> firWires;


    public int lightsInSecond = 0;
    public List<int> secLightsToToggle;
    public List<GameObject> secWires;


    private bool firstSlotIn;
    private bool secondSlotIn;

    void Update()
    {
        firstSlotIn = firstSlot.GetComponent<TriangleToHole>().triangleInHole;
        secondSlotIn = secondSlot.GetComponent<CircleToHole>().circleInHole;

        if (firstSlotIn)
        {
            for (int i = 0; i < firWires.Count; i++)
            {
                firWires[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (secondSlotIn)
        {
            for (int i = 0; i < secWires.Count; i++)
            {
                secWires[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < firWires.Count; i++)
            {
                firWires[i].GetComponent<MeshRenderer>().enabled = false;
            }

            for (int i = 0; i < secWires.Count; i++)
            {
                secWires[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if(firstSlotIn)
        {
            ToggleLightSection(lightsInFirst, firstLightsToToggle);

            //ToggleLight(lights[0]);
            //ToggleLight(lights[1]);
            //ToggleLight(lights[4]);
            //ToggleLight(lights[6]);
        }

        if(secondSlotIn)
        {
            ToggleLightSection(lightsInSecond, secLightsToToggle);

            //ToggleLight(lights[2]);
            //ToggleLight(lights[4]);
            //ToggleLight(lights[5]);
            //ToggleLight(lights[6]);
        }
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
