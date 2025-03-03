using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float spawnInterval = 2f;
    public float rockSpeed = 5f;

    private bool spawnAtPoint1 = true;  // Track which point to spawn at

    void Start()
    {
        // Start the spawning
        InvokeRepeating("SpawnRock", 0f, spawnInterval);
    }

    void SpawnRock()
    {
        // Choose the spawn point
        Transform spawnPoint = spawnAtPoint1 ? spawnPoint1 : spawnPoint2;

        // Spawn the rock
        GameObject newRock = Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = newRock.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Pushes the rock
            rb.velocity = new Vector3(rockSpeed, 0f, 0f);
        }

        // Alternates the spawn point
        spawnAtPoint1 = !spawnAtPoint1;
    }
}
