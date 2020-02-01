using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public int detectionLayer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            detectionLayer++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            detectionLayer--;
        }
    }
}
