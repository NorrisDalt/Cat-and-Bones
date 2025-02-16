using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 10f;
    public float fireDelay = 0.5f; // delay before firing
    public float resetTime = 3f; // Time before it can be triggered again

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player")) // Prevents the player from spamming the pressure plate
        {
            StartCoroutine(FireArrowWithDelay());
        }
    }

    IEnumerator FireArrowWithDelay()
    {
        isTriggered = true; // Prevent multiple triggers
        yield return new WaitForSeconds(fireDelay); // Wait half a second before firing
        FireArrow();
        yield return new WaitForSeconds(resetTime); // Pressure plate cooldown
        isTriggered = false; // Reset the trigger
    }

    void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = arrowSpawnPoint.forward * arrowSpeed;
        }
    }
}
