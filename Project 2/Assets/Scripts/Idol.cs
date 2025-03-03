using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    public GameObject secretExit;
    public static bool idolCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                idolCollected = true;

                Destroy(gameObject);

                Destroy(secretExit);
            }
        }
    }
}
