using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform destination;

    public TriangleToHole triangle;
    public SquareToHole square;
    public CircleToHole circle;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = destination.position;
        this.transform.parent = GameObject.Find("ObjectHolder").transform;

        rigid.velocity = new Vector3(0, 0, 0);

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

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
