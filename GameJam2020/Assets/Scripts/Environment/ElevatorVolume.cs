using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorVolume : MonoBehaviour
{
    [SerializeField] float verticalSpeed;
    public bool elevatorIsOn = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && elevatorIsOn)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, verticalSpeed, rb.velocity.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && elevatorIsOn)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
}
