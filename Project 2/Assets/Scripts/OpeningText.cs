using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpeningText : MonoBehaviour
{
    public TextMeshProUGUI openingText;
    public float fadeDuration = 2f;
    public float displayDuration = 2f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = openingText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = openingText.gameObject.AddComponent<CanvasGroup>();
        }

        StartCoroutine(FadeTextSequence());
    }

    IEnumerator FadeTextSequence()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayDuration);

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }
}
