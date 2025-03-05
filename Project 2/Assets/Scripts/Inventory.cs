using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int keyCount = 0;
    private bool hasGem = true;

    public GameObject gem;
    public Transform gemSlot;
    public Entrance entrance;
    public AudioSource itemPickup;
    public TextMeshProUGUI objectiveText;

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

            }
        }

        if (other.CompareTag("Key"))
        {
            keyCount++;
            Destroy(other.gameObject);

            if (itemPickup)
            {
                itemPickup.Play();
            }

            if (objectiveText)
            {
                if (keyCount == 1)
                {
                    objectiveText.text = "Find the second key.";
                }
                else if (keyCount == 2)
                {
                    objectiveText.text = "Find the secret door.";
                }
            }
        }

        if (other.CompareTag("KeyDoor") && keyCount >= 2)
        {
            Destroy(other.gameObject);
            if (objectiveText)
            {
                objectiveText.text = "Collect the idol.";
            }
        }

        if (other.CompareTag("DisplayObjective"))
        {
            if (objectiveText)
            {
                objectiveText.text = "Find the two keys.";
            }
        }
    }
}
