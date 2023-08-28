using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity = 8f;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float mouseX, mouseY;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate on the y axis of the player by mouseX
        transform.Rotate(Vector3.up, mouseX);
        // Pitch the camera up and down based on mouseY
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivity;
        mouseY = mouseInput.y * sensitivity;
    }
}
