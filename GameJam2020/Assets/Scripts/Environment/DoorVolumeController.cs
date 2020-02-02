using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVolumeController : MonoBehaviour
{
    [SerializeField] bool doorEnabledByDefault = false;
    [SerializeField] GameObject linkedPuzzle;
    bool doorEnabled = false;

    PuzzleFinalCheck linkedPuzzleScript;
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
        linkedPuzzleScript = linkedPuzzle.GetComponent<PuzzleFinalCheck>();
    }

    private void OnTriggerStay(Collider other)
    {
        doorEnabled = linkedPuzzleScript.puzzleDone;
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
