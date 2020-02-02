using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVolumeController : MonoBehaviour
{
    [SerializeField] bool doorEnabledByDefault = false;
    bool doorEnabled = false;

    public bool DoorEnabled
    {
        set
        {
            doorEnabled = value;
            SetDoorState(false);    // Close door if it is open.
        }
    }

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorEnabled = doorEnabledByDefault;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && doorEnabled)
        {
            SetDoorState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SetDoorState(false);
        }
    }

    void SetDoorState(bool doorState)
    {
        anim.SetBool("DoorOpen", doorState);
    }
}
