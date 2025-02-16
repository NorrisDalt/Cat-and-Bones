using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyID = "Key"; // Key required to open

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasKey(requiredKeyID))
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("The door is locked! You need a key.");
            }
        }
    }

    void UnlockDoor()
    {
        Debug.Log("Door Unlocked!");
        Destroy(gameObject); // Completely remove the door
    }
}
