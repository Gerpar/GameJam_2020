using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardPanel : MonoBehaviour
{
    public KeyCardPickUp playerKeyCard;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && playerKeyCard.hasKeyCard)
        {
            //Play swipe animation
            Debug.Log("Entered trigger");
            //Open door???
            if(GetComponent<DoorVolumeController>())
            {
                gameObject.GetComponent<DoorVolumeController>().DoorEnabled = true;
            }
        }
    }
}
