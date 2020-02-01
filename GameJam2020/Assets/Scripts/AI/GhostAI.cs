using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject detectors;
    [SerializeField] GameObject patrolWaypointParent;

    Vector3[] patrolWaypoints;

    GameObject playerObj;
    PlayerDetection playerDetection;
    PlayerController playerController;
    int waypointIndex;
    bool patrolRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerDetection = detectors.GetComponent<PlayerDetection>();
        playerController = playerObj.GetComponent<PlayerController>();

        Transform[] patrolChildren = patrolWaypointParent.GetComponentsInChildren<Transform>();
        patrolWaypoints = new Vector3[patrolChildren.Length];

        for(int i = 0; i < patrolWaypoints.Length; i++)
        {
            patrolWaypoints[i] = patrolChildren[i].position;
        }
        Destroy(patrolWaypointParent);
    }

    void Awake()
    {
        StartCoroutine(Patrol(patrolWaypoints));
    }

    // Update is called once per frame
    void Update()
    {
        if((playerDetection.detectionLayer >= 2 && playerController.FlashLightOn) || playerDetection.detectionLayer >= 4)
        {
            StopAllCoroutines();
            patrolRunning = false;
            PointTowardsPoint(playerObj.transform.position);
            MoveForward();
        }
        else if(!patrolRunning)
        {
            StartCoroutine(Patrol(patrolWaypoints));
        }
    }

    void PointTowardsPoint(Vector3 point)
    {
        Vector3 direction = (point - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void MoveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    // Coroutines
    IEnumerator Patrol(Vector3[] waypoints)
    {
        patrolRunning = true;

        // Find the closest waypoint
        float minDist = Mathf.Infinity;
        for(int i = 0; i < patrolWaypoints.Length; i++)
        { 
            float dist = Vector3.Distance(waypoints[i], transform.position);
            if(dist < minDist)
            {
                waypointIndex = i;
                minDist = dist;
            }
        }

        // Patrol waypoints
        while (true)
        {
            while(waypointIndex < waypoints.Length)
            {
                yield return StartCoroutine(MoveToWaypoint(waypoints[waypointIndex]));
                waypointIndex++;
            }
            waypointIndex = 0;
        }
    }

    IEnumerator MoveToWaypoint(Vector3 waypoint)
    {
        while(Vector3.Distance(waypoint, transform.position) > 1)
        {
            PointTowardsPoint(waypoint);
            MoveForward();
            yield return new WaitForEndOfFrame();
        }
    }
}
