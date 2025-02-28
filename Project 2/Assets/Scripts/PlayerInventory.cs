using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<string> collectedKeys = new HashSet<string>();
    private bool hasIdol = false;
    public TextMeshProUGUI warningText;

    public void CollectKey(string keyID)
    {
        collectedKeys.Add(keyID);
        Debug.Log("Collected key: " + keyID);
    }

    public bool HasKey(string keyID)
    {
        return collectedKeys.Contains(keyID);
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
        if (warningText != null)
        {
            warningText.text = "GET OUT OF THERE!";
            warningText.enabled = true;
        }

        yield return new WaitForSeconds(1f);

        if (warningText != null)
        {
            warningText.enabled = false;
        }

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
