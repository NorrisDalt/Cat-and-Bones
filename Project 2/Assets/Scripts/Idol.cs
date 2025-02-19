using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectIdol();
                Destroy(gameObject);
            }
        }
    }
}
