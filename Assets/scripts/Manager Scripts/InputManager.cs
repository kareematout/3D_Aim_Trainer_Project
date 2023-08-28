using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   [SerializeField] Movement movement;
   [SerializeField] MouseLook mouseLook;
   [SerializeField] Shoot shoot;
   [SerializeField] GameObject settings_obj;
    PlayerControls controls;
    PlayerControls.GroundActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerControls();
        groundMovement = controls.Ground;

        //groundMovement.[action].performed += context => function
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJump();

        // Susbscribe to the mouse x and mouse y inputs and then assigns those values given by the player controller
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Shoot.performed += _ => shoot.AttemptShot();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDestroy() {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movement.RecieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
    }
}
