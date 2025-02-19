using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject barrier;
    public GameObject exitTrigger;

    private PlayerInventory playerInventory;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerInventory = player.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (playerInventory != null && playerInventory.HasIdol() && barrier != null)
        {
            Destroy(barrier); // Remove the barrier when the idol is collected
            Debug.Log("Barrier Removed!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInventory != null && playerInventory.HasIdol())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
        }
    }
}
