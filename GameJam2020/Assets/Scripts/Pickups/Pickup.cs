using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject destination;

    public TriangleToHole triangle;
    public SquareToHole square;
    public CircleToHole circle;

    private Rigidbody rigid;

    bool beingHeld = false;

    private Vector3 originalSpawnPos;
    private Vector3 lastPosition;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

        if (destination == null)
        {
            destination = GameObject.Find("Player Object Holder");
        }
        originalSpawnPos = transform.position;
    }

    private void Update()
    {
        if (beingHeld)
        {
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            rigid.angularVelocity = new Vector3(0, 0, 0);
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))    // Limit grabbing distance
        {
            if (hit.transform == transform)
            {
                beingHeld = true;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = destination.transform.position;
                this.transform.parent = destination.transform;

                rigid.velocity = new Vector3(0, 0, 0);

                transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));

                if (this.CompareTag("TrianglePiece"))
                {
                    if (triangle.triangleInHole == true)
                    {
                        triangle.triangleInHole = false;
                    }
                }

                if (this.CompareTag("SquarePiece"))
                {
                    if (square.squareInHole == true)
                    {
                        square.squareInHole = false;
                    }
                }

                if (this.CompareTag("CirclePiece"))
                {
                    if (circle.circleInHole == true)
                    {
                        circle.circleInHole = false;
                    }
                }
            }
        }
    }

    private void OnMouseUp()
    {
        beingHeld = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickupRespawn"))
        {
            transform.position = originalSpawnPos;
        }
    }
}
