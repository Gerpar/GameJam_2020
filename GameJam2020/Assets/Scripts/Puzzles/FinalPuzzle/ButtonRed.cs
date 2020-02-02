using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRed : MonoBehaviour
{
    public PuzzleFinalCheck puzzleCheck;

    public GameObject triangleLock;
    public GameObject squareLock;
    public GameObject circleLock;

    public List<GameObject> lights;

    public int lightsInTriangle = 0;
    public List<int> triLightsToToggle;
    public List<GameObject> triWires;

    public int lightsInSquare = 0;
    public List<int> squLightsToToggle;
    public List<GameObject> squWires;

    public int lightsInCircle = 0;
    public List<int> cirLightsToToggle;
    public List<GameObject> cirWires;

    private bool triangle;
    private bool square;
    private bool circle;

    void Update()
    {
        triangle = triangleLock.GetComponent<TriangleToHole>().triangleInHole;
        square = squareLock.GetComponent<SquareToHole>().squareInHole;
        circle = circleLock.GetComponent<CircleToHole>().circleInHole;

        if (triangle)
        {
            for (int i = 0; i < triWires.Count; i++)
            {
                triWires[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (square)
        {
            for (int i = 0; i < squWires.Count; i++)
            {
                squWires[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (circle)
        {
            for (int i = 0; i < cirWires.Count; i++)
            {
                cirWires[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < triWires.Count; i++)
            {
                triWires[i].GetComponent<MeshRenderer>().enabled = false;
            }

            for (int i = 0; i < squWires.Count; i++)
            {
                squWires[i].GetComponent<MeshRenderer>().enabled = false;
            }

            for (int i = 0; i < cirWires.Count; i++)
            {
                cirWires[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (triangle)
        {
            ToggleLightSection(lightsInTriangle, triLightsToToggle);
        }

        if (square)
        {
            ToggleLightSection(lightsInSquare, squLightsToToggle);
        }

        if (circle)
        {
            ToggleLightSection(lightsInCircle, cirLightsToToggle);
        }
    }

    public void ToggleLightSection(int numLights, List<int> lightsToToggle)
    {
        for(int i = 0; i < numLights; i++)
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
