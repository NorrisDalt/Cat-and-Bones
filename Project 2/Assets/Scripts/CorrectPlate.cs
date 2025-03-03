using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPlate : MonoBehaviour
{
    public Renderer plateRenderer; // Assign this in the Inspector
    private Color originalColor; // Store original color

    private void Start()
    {
        if (plateRenderer != null)
        {
            originalColor = plateRenderer.material.color; // Store the starting color
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Only reacts to the player
        {
            if (plateRenderer != null)
            {
                plateRenderer.material.color = Color.green; // Change color to green
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (plateRenderer != null)
            {
                plateRenderer.material.color = originalColor; // Reset to original color
            }
        }
    }
}
