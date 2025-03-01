using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonEnemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private bool isAwakened = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    void Update()
    {
        if (isAwakened && player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void Awaken(Transform transform)
    {
        isAwakened = true;
        agent.enabled = true;
        Debug.Log(gameObject.name + " has awakened!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
        }
    }
}
