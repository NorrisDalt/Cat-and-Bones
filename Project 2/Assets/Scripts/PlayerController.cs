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

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 forward = UnityEngine.Camera.main.transform.forward;
        Vector3 right = UnityEngine.Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
        Vector3 forwardVertInput = verticalInput * forward;
        Vector3 rightHoriInput = horizontalInput * right;

        Vector3 moveDirectionRelCam = forwardVertInput + rightHoriInput;

        rb.MovePosition(transform.position + moveDirectionRelCam * currentSpeed * Time.fixedDeltaTime);
    }
}
