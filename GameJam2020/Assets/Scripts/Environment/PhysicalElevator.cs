using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalElevator : MonoBehaviour
{
    [SerializeField] float elevatorSpeed;
    [SerializeField] GameObject endposCheckpoint;

    private Vector3 startPos;
    
    IEnumerator MoveToPoint(Vector3 endPos)
    {
        while(Vector3.Distance(transform.position, endPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, elevatorSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator PingPong()
    {
        while(true)
        {
            yield return MoveToPoint(endposCheckpoint.transform.position);
            yield return new WaitForSeconds(2.0f);
            yield return MoveToPoint(startPos);
            yield return new WaitForSeconds(2.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(PingPong());
    }
}
