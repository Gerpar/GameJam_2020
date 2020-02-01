using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleToHole : MonoBehaviour
{
    public bool circleInHole = false;

    private Rigidbody rigid;

    private Pickup pickUp;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pickUp = GetComponent<Pickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CircleHole"))
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = false;

            transform.parent = other.transform;
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = other.transform.localRotation;
            rigid.velocity = new Vector3(0, 0, 0);

            Destroy(pickUp);

            circleInHole = true;
            Debug.Log(circleInHole);
        }
    }
}
