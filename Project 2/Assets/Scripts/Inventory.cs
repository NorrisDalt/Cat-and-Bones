using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour
{
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
    }
}

