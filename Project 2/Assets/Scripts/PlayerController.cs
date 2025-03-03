using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float walkSpeed = 1f;
    public float sprintSpeed = 1.5f;
    public Rigidbody rb;
    private float currentSpeed;

    // Input mappings
    const string keyboardHorizontal = "Horizontal";
    const string keyboardVertical = "Vertical";
    const string controllerHorizontal = "LeftStickX"; // Left Stick X
    const string controllerVertical = "LeftStickY";   // Left Stick Y
    const string sprintKey = "Sprint"; // Sprint Button (Controller)

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Get input from Keyboard (WASD / Arrow Keys) and Controller (Left Stick)
        float horizontalInput = Input.GetAxisRaw(keyboardHorizontal) + Input.GetAxis(controllerHorizontal);
        float verticalInput = Input.GetAxisRaw(keyboardVertical) + Input.GetAxis(controllerVertical);

        // Get camera-relative directions
        Vector3 forward = UnityEngine.Camera.main.transform.forward;
        Vector3 right = UnityEngine.Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDirectionRelCam = (verticalInput * forward) + (horizontalInput * right);

        // Sprinting (Keyboard: LeftShift, Controller: Assigned Sprint Button)
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton(sprintKey))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // Apply movement
        rb.MovePosition(transform.position + moveDirectionRelCam * currentSpeed * Time.fixedDeltaTime);
    }
}
