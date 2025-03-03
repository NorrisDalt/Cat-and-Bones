using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Idol.idolCollected) // Check if idol is collected
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
        }
    }
}
