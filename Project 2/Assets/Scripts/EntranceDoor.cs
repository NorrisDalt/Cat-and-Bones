using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntranceDoor : MonoBehaviour
{
    public GameObject gemInHand;
    public GameObject gemOnDoor;
    public GameObject door;

    public ParticleSystem gemSparkleEffect;
    public AudioSource gemUnlocked;

    private bool isActivated = false;

    private void Start()
    {
        if (gemOnDoor) gemOnDoor.SetActive(false);
        if (gemSparkleEffect) gemSparkleEffect.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            StartCoroutine(HandleGemAndDoor());
        }
    }

    private IEnumerator HandleGemAndDoor()
    {
        isActivated = true;

        if (gemInHand) gemInHand.SetActive(false);
        if (gemOnDoor) gemOnDoor.SetActive(true);
        if (gemSparkleEffect) gemSparkleEffect.Play();

        yield return new WaitForSeconds(2f);

        if (gemOnDoor) gemOnDoor.SetActive(false);
        if (door) door.SetActive(false);
        if (gemUnlocked) gemUnlocked.Play();

        yield return new WaitForSeconds(1f);

        if (gemSparkleEffect) gemSparkleEffect.Stop();
    }
}
