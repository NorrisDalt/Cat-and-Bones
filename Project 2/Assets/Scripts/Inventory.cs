using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
    private int keyCount = 0;
    private bool hasGem = true;

    public GameObject gem;
    public Transform gemSlot;
    public Entrance entrance;

    void Start()
    {
        entrance = FindObjectOfType<Entrance>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entrance") && hasGem)
        {
            hasGem = false;

            if (entrance != null)
            {
                //entrance.OpenEntrance();
            }
        }

        if (other.CompareTag("Key"))
        {
            keyCount++; // Counts number of keys
            Destroy(other.gameObject); // Destroys key
        }

        if (other.CompareTag("KeyDoor") && keyCount >= 2) // Checks if player has 2 keys
        {
            Destroy(other.gameObject); // Deletes the door
        }
    }
}
