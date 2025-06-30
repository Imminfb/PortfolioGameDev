using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image fadeImage;

    [Range(0.5f, 5f)]
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void Start()
    {
        
        StartCoroutine(FadeOut());
    }

    
    public IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color startColor = new Color(0, 0, 0, 0);
        Color endColor = new Color(0, 0, 0, 1);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, elapsed / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
    }

    
    public IEnumerator FadeOut()
    {
        float elapsed = 0f;
        Color startColor = new Color(0, 0, 0, 1);
        Color endColor = new Color(0, 0, 0, 0);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, elapsed / fadeDuration);
            yield return null;
        }

        fadeImage.color = endColor;
    }
}
