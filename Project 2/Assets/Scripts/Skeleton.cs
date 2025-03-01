using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 0.4f;
    public float rotationSpeed = 3f;
    private int currentWaypointIndex = 0;
    private Transform targetWaypoint;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            targetWaypoint = waypoints[currentWaypointIndex];
        }
    }

    void Update()
    {
        if (targetWaypoint != null)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        RotateTowards(targetWaypoint.position);

        if (transform.position == targetWaypoint.position)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            targetWaypoint = waypoints[currentWaypointIndex];
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
