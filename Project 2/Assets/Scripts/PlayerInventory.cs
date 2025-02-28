using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    private bool hasGem = true;

    public GameObject gem;
    public Transform gemSlot;
    public Entrance entrance;
    private bool hasIdol = false;

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
                entrance.OpenEntrance();
            }
        }
    }
    public void CollectIdol()
    {
        if (hasIdol) return;

        hasIdol = true;
        Debug.Log("Collected the Idol!");
        StartCoroutine(AwakenSkeletonsWithDelay());
    }
    private IEnumerator AwakenSkeletonsWithDelay()
    {
        yield return new WaitForSeconds(1f);

        SkeletonAI[] skeletons = FindObjectsOfType<SkeletonAI>();
        foreach (SkeletonAI skeleton in skeletons)
        {
            skeleton.Awaken(transform);
        }
    }

    public bool HasIdol()
    {
        return hasIdol;
    }
}
