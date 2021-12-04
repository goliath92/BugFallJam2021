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
    
    void Start()
    {
        
    }

    
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

    }
}
