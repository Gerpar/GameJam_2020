using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVelocity;
    [SerializeField] float sprintMulti;

    [Header("Camera Settings")]
    [SerializeField] float cameraSensitivity;
    [SerializeField] Camera camera;
    [SerializeField] float minCamLimit, maxCamLimit;

    [Header("Footstep Settings")]
    [SerializeField] AudioClip[] footstepClips;
    [SerializeField] float footstepDelay;

    Vector3 inputVector;
    Rigidbody rb;
    bool canJump = true;
    Vector2 camRot;
    float timeToNextFootstep; // Keeps track of when the next footstep can play
    AudioSource src;
    bool firstFootstep = true;  // Keeps track of which footstep sound to play

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
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

        if(Input.GetButton("Sprint"))   // Multiplies the speed if the player is sprinting
        {
            inputVector *= sprintMulti;
        }

        rb.transform.position += transform.forward * inputVector.z;
        rb.transform.position += transform.right * inputVector.x;

        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        if(timeToNextFootstep < Time.time && inputVector != Vector3.zero && canJump)
        {
            if(firstFootstep)
            {
                src.PlayOneShot(footstepClips[0]);
            }
            else
            {
                src.PlayOneShot(footstepClips[1]);
            }

            firstFootstep = !firstFootstep;

            if (Input.GetButton("Sprint"))   // Multiplies the speed if the player is sprinting
            {
                timeToNextFootstep = Time.time + (footstepDelay / sprintMulti);
            }
            else
            {
                timeToNextFootstep = Time.time + footstepDelay;
            }
        }
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
