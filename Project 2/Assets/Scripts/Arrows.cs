using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If the arrow hits the player, deal damage
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Triggers scene reload
            }
        }

        // Destroys the arrow on collision with anything
        Destroy(gameObject);
    }
}
