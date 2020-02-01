using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject detectors;

    GameObject playerObj;
    Rigidbody rb;
    PlayerDetection playerDetection;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        playerDetection = detectors.GetComponent<PlayerDetection>();
        playerController = playerObj.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((playerDetection.detectionLayer >= 2 && playerController.FlashLightOn) || playerDetection.detectionLayer >= 4)
        {
            PointTowardsPoint(playerObj.transform.position);
            MoveForward();
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
        rb.transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
