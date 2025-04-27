using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private void Start()
    {
        Idol.idolCollected = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Idol.idolCollected) // Check if idol is collected
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Win");
        }
    }
}
