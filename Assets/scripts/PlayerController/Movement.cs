using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float JumpHeight = 3.5f;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -30f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] GameObject settings_obj;

    gameSettings settings;
    // Vector3 -> (0,0,0)
    // Vector2 -> (0,0)
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;

    bool jump;
    bool isGrounded;

    void Start() {
        settings = settings_obj.GetComponent<gameSettings>();
    }
    // Update is called once per frame
    void Update()
    {
        if(settings.MovementEnabled == false) {jump = false; return;}
        // Calculate movement vectors in each direction
        isGrounded = Physics.CheckSphere(transform.position, .1f, groundMask);
        if(isGrounded) {
            verticalVelocity.y = 0;
        }  

        //Create proper vector based on input, time, and speed and set
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        // Checking for jump
        if(jump) 
        {
            if(isGrounded) 
            {
                // Physics formula to calculate velocity
                verticalVelocity.y = Mathf.Sqrt(-2f * JumpHeight * gravity);
            }
            jump = false;
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void RecieveInput(Vector2 _horizontalInput) {
        horizontalInput = _horizontalInput;
    }
    public void OnJump()
    {
        jump = true;
    }

}
