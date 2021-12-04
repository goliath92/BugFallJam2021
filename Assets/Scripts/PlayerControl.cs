using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    private bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;

    private float groundDistance = 0.4f;

    Vector3 velocity;
    
    [Header("Values")]
    public float speed = 10f;
    public float gravity = -10;
    public float jumpHeight = 2f;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        velocity.y += gravity * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        controller.Move(velocity * Time.deltaTime);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

    }
}
