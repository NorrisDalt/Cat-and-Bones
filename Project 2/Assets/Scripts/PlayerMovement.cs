using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 3f;
    private Rigidbody rb;

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        Vector3 forwardVertInput = verticalInput * forward;
        Vector3 rightHoriInput = horizontalInput * right;

        Vector3 moveDirectionRelCam = forwardVertInput + rightHoriInput;

        rb.MovePosition(transform.position + moveDirectionRelCam * speed * Time.fixedDeltaTime);
    }
}
