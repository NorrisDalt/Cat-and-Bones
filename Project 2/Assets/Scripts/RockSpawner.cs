using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;  
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float spawnInterval = 2f;
    public float rockSpeed = 5f;

    private bool spawnAtPoint1 = true;
    void Start()
    {
        InvokeRepeating("SpawnRock", 0f, spawnInterval);
    }

    void SpawnRock()
    {
        Transform spawnPoint = spawnAtPoint1 ? spawnPoint1 : spawnPoint2;

        GameObject newRock = Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = newRock.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Add force to move the rock along the X-axis
            rb.velocity = new Vector3(rockSpeed, 0f, 0f);
        }

        spawnAtPoint1 = !spawnAtPoint1;
    }
}
