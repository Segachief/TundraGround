using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour // Script by Michael Arthur
{
    public GameObject introTextObject; // Assign the UI text object in the inspector

    void Start()
    {
        introTextObject.SetActive(false); // Ensure the intro text is initially inactive
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger area to show the intro text
        {
            introTextObject.SetActive(true); // Show the intro text when the player enters the trigger area
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player exits the trigger area to hide the intro text
        {
            introTextObject.SetActive(false); // Hide the intro text when the player exits the trigger area
        }
    }
}