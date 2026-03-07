using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Handles fade-in and fade-out transitions using a CanvasGroup.
// Attach this script to a UI Canvas with a full-screen Image.
// Typically a black image, but may work with other colours and regular images.
public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance; // Singleton

    [Header("Fade Settings")]
    [Range(0.1f, 5f)] public float fadeDuration = 1f; // Time in seconds
    public Color fadeColor = Color.black; // Default fade color

    private CanvasGroup canvasGroup;
    private Image fadeImage;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        // Ensure CanvasGroup & Image exist
        canvasGroup = GetComponent<CanvasGroup>();
        fadeImage = GetComponent<Image>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        if (fadeImage == null)
            fadeImage = gameObject.AddComponent<Image>();

        fadeImage.color = fadeColor;
        canvasGroup.alpha = 0f; // Start transparent
        canvasGroup.blocksRaycasts = false; // Allow clicks when transparent
    }

    // Fades the screen to black.
    public IEnumerator FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
    }

    // Fades the screen from black to transparent.
    public IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        canvasGroup.blocksRaycasts = false;
    }

    // Fades out, loads a scene, then fades in.
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeSceneRoutine(sceneName));
    }

    private IEnumerator FadeSceneRoutine(string sceneName)
    {
        yield return FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return FadeIn();
    }
}