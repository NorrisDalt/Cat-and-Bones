using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    private int currentWaypointIndex = 0;
    private Transform targetWaypoint;
    private bool isRotating = false;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            targetWaypoint = waypoints[currentWaypointIndex];
        }
    }

    void Update()
    {
        if (targetWaypoint != null && !isRotating)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        direction.y = 0;

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            StartCoroutine(RotateToNextWaypoint());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
            RotateTowards(direction);
        }
    }

    void RotateTowards(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    IEnumerator RotateToNextWaypoint()
    {
        isRotating = true;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
        targetWaypoint = waypoints[currentWaypointIndex];
        isRotating = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}