using UnityEngine;

public class IntroText : MonoBehaviour
{
    public GameObject Introtext;
    public GameObject IntrotextObject;
    private bool playerInRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IntrotextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) // Check if the player enters the trigger area to show the prompt
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Indicate the player is in range

            IntrotextObject.SetActive(true); // Show the prompt text when the player enters the trigger area
        }
    }

    void OnTriggerExit2D(Collider2D other) // Check if the player exits the trigger area to hide the prompt
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Indicate the player is no longer in range

            IntrotextObject.SetActive(false); // Hide the prompt text when the player exits the trigger area
        }
    }    
}

