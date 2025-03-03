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
        float mouseX = Input.GetAxis(mouseXAxis) * sensitivity;
        float mouseY = Input.GetAxis(mouseYAxis) * sensitivity;
        float controllerX = Input.GetAxis(controllerXAxis) * sensitivity;
        float controllerY = Input.GetAxis(controllerYAxis) * sensitivity;

        rotation.x += mouseX + controllerX;
        rotation.y += mouseY + controllerY;

        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;
    }
}