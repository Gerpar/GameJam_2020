using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVelocity;
    [SerializeField] float cameraSensitivity;
    [SerializeField] float sprintMulti;
    [SerializeField] Camera camera;
    [SerializeField] float minCamLimit, maxCamLimit;

    Vector3 inputVector;
    Rigidbody rb;
    bool canJump = true;
    Vector2 camRot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Movement();
        Jumping();
    }

    void Movement()
    {
        inputVector.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        inputVector.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if(Input.GetButton("Sprint"))
        {
            inputVector *= sprintMulti;
        }

        Debug.Log(inputVector.z);

        rb.transform.position += transform.forward * inputVector.z ;
        rb.transform.position += transform.right * inputVector.x;

        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void Jumping()
    {
        if(Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
            canJump = false;
        }
    }

    void Rotation()
    { 
        camRot.x += cameraSensitivity * Input.GetAxis("Mouse X");
        camRot.y -= cameraSensitivity * Input.GetAxis("Mouse Y");

        camRot.y = Mathf.Clamp(camRot.y, minCamLimit, maxCamLimit);  // Clamp vertical camera rotation

        transform.eulerAngles = new Vector3(0.0f, camRot.x, 0.0f);  // Rotate player object
        camera.transform.eulerAngles = new Vector3(camRot.y, camRot.x, 0.0f); // Rotate camera attached to player
    }

    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }
}
