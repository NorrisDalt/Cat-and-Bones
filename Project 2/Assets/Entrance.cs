using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string requiredKeyID = "Key"; // Key required to open
    public Animator anim;
    public Transform player;
    public Transform gemdoor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasKey(requiredKeyID))
            {
                anim.SetTrigger("Open");
            }
        }
    }
}
