using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;

    const string mouseXAxis = "Mouse X";
    const string mouseYAxis = "Mouse Y";
    const string controllerXAxis = "RightStickX"; // Right Stick X Axis
    const string controllerYAxis = "RightStickY"; // Right Stick Y Axis

    void Start()
    {
        // Hide the cursor when the game starts
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get input from both Mouse and Controller
        float mouseX = Input.GetAxis(mouseXAxis) * sensitivity;
        float mouseY = Input.GetAxis(mouseYAxis) * sensitivity;
        float controllerX = Input.GetAxis(controllerXAxis) * sensitivity;
        float controllerY = Input.GetAxis(controllerYAxis) * sensitivity;

        // Add both inputs together to allow seamless switching
        rotation.x += mouseX + controllerX;
        rotation.y += mouseY + controllerY;

        // Clamp vertical rotation to prevent flipping
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        // Apply rotation
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;
    }
}