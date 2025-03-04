using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1f;
    public float sprintSpeed = 1.5f;
    public Rigidbody rb;
    private float currentSpeed;

    public AudioSource footsteps;
    public float stepRate = 0.5f;
    public float sprintStepRate = 0.35f;
    private float stepCooldown = 0f;

    const string keyboardHorizontal = "Horizontal";
    const string keyboardVertical = "Vertical";
    const string controllerHorizontal = "LeftStickX";
    const string controllerVertical = "LeftStickY";
    const string sprintKey = "Sprint";

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw(keyboardHorizontal) + Input.GetAxis(controllerHorizontal);
        float verticalInput = Input.GetAxisRaw(keyboardVertical) + Input.GetAxis(controllerVertical);

        Vector3 forward = UnityEngine.Camera.main.transform.forward;
        Vector3 right = UnityEngine.Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDirectionRelCam = (verticalInput * forward) + (horizontalInput * right);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton(sprintKey))
        {
            currentSpeed = sprintSpeed;
            stepRate = sprintStepRate;
        }
        else
        {
            currentSpeed = walkSpeed;
            stepRate = 0.5f;
        }

        rb.MovePosition(transform.position + moveDirectionRelCam * currentSpeed * Time.fixedDeltaTime);

        if (moveDirectionRelCam.magnitude > 0.1f)
        {
            PlayFootsteps();
        }
        else
        {
            footsteps.Stop();
        }
    }

    private void PlayFootsteps()
    {
        if (footsteps && Time.time >= stepCooldown)
        {
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
                footsteps.volume = 5f;

            }
            stepCooldown = Time.time + stepRate;
        }
    }
}