using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPressurePlates : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 10f;
    public float fireDelay = 0.5f; // Delay before firing
    public float resetTime = 3f; // Time before it can be triggered again
    public Renderer plateRenderer; // Reference to the plate's renderer
    private Color originalColor; // Store original color
    public AudioSource arrowShoot;

    private bool isTriggered = false;

    private void Start()
    {
        if (plateRenderer != null)
        {
            originalColor = plateRenderer.material.color; // Store the starting color
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player")) // Prevents spamming
        {
            if (plateRenderer != null)
            {
                plateRenderer.material.color = Color.red; // Change color to red
            }
            StartCoroutine(FireArrowWithDelay());
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

    IEnumerator FireArrowWithDelay()
    {
        isTriggered = true; // Prevent multiple triggers
        yield return new WaitForSeconds(fireDelay); // Wait before firing
        FireArrow();
        yield return new WaitForSeconds(resetTime); // Cooldown time
        isTriggered = false; // Reset trigger
    }

    void FireArrow()
    {
        if (arrowShoot)
        {
            arrowShoot.Play();
        }
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation * Quaternion.Euler(0, 0, 90)); // Fixes rotation
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = arrowSpawnPoint.right * -arrowSpeed;
        }
    }
}
