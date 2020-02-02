using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPickUp : MonoBehaviour
{
    public GameObject keycard;

    public bool hasKeyCard = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyCard"))
        {
            hasKeyCard = true;

            Destroy(keycard);
        }
    }
}
