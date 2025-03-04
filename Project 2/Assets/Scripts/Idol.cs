using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    public GameObject secretExit;
    public GameObject idolInHand;
    public static bool idolCollected = false;
    public AudioSource itemPickup;

    private void Start()
    {
        if (idolInHand) idolInHand.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                idolCollected = true;

                Destroy(gameObject);

                if (idolInHand) idolInHand.SetActive(true);

                if (itemPickup)
                {
                    itemPickup.Play();
                }

                Destroy(secretExit);
            }
        }
    }
}
