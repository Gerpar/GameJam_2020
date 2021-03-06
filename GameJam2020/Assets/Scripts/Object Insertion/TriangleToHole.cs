﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleToHole : MonoBehaviour
{
    public bool triangleInHole = false;

    private Rigidbody rigid;

    private Pickup pickUp;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pickUp = GetComponent<Pickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriangleHole"))
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = false;

            transform.parent = other.transform;
            transform.localPosition = new Vector3(0, 0, 0);
            transform.rotation = other.transform.localRotation;
            rigid.velocity = new Vector3(0, 0, 0);

            rigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;

            //Destroy(pickUp);

            triangleInHole = true;
            Debug.Log(triangleInHole);
        }
    }
}
