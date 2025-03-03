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
    const string controllerXAxis = "RightStickX";
    const string controllerYAxis = "RightStickY";

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis(mouseXAxis);
        float mouseY = Input.GetAxis(mouseYAxis);

        float controllerX = Input.GetAxis(controllerXAxis);
        float controllerY = Input.GetAxis(controllerYAxis);

        float adjustedMouseX = mouseX * sensitivity;
        float adjustedMouseY = mouseY * sensitivity;
        float adjustedControllerX = controllerX * sensitivity;
        float adjustedControllerY = controllerY * sensitivity;

        if (Mathf.Abs(adjustedMouseX) > 0.1f || Mathf.Abs(adjustedMouseY) > 0.1f)
        {
            rotation.x += adjustedMouseX;
            rotation.y += adjustedMouseY;
        }
        else
        {
            rotation.x += adjustedControllerX;
            rotation.y += adjustedControllerY;
        }

        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;
    }
}