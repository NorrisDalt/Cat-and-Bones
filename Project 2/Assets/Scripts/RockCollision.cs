using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{

    public int damageAmount = 1;

    void OnCollisionEnter(Collision collision)
    {
        // If the arrow hits the player, deal damage
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Triggers scene reload
            }
        }

        // Destroys the rock if it hits the back wall
        if (collision.gameObject.CompareTag("BackWall"))
        {
            Destroy(gameObject);
        }
    }
}
