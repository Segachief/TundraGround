using UnityEngine;
using TMPro;

public class BridgeBuilder : MonoBehaviour // Script by Michael Arthur
{
    public GameObject bridge; // Assign the bridge in the inspector
    public GameObject promptTextObject; // Assign the UI text object in the inspector
    public TextMeshProUGUI promptText; // Assign the TextMeshProUGUI component in the inspector
    public int woodCost = 10; // Set the wood cost for building the bridge (can be changed in the inspector)
    private bool playerInRange; // Tracks if the player is within the trigger area 

    void Start()
    {
        bridge.SetActive(false); // Ensure the bridge is initially inactive
        promptTextObject.SetActive(false); // Ensure the prompt text is initially inactive
    }

    void Update()
    {
        if (playerInRange) // Check if the player is in range to show the prompt
        {
            promptText.text = // Display the prompt with the wood cost and the key to build the bridge
                "Press E to build bridge\n" +
                "Cost: " + woodCost + " Wood";

            if (Input.GetKeyDown(KeyCode.E)) // Check if the player presses the E key to build the bridge
            {
                if (InventoryManager.instance.Wood >= woodCost) // Check if the player has enough wood to build the bridge
                {
                    InventoryManager.instance.AddWood(-woodCost); // Deduct the wood cost from the player's inventory
                    bridge.SetActive(true); // Activate the bridge to allow the player to cross
                    promptTextObject.SetActive(false); // Hide the prompt text after building the bridge
                    gameObject.SetActive(false); // Deactivate the trigger area to prevent building the bridge again
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Check if the player enters the trigger area to show the prompt
    {
        if (other.CompareTag("Player")) 
        {
            playerInRange = true; // Indicate the player is in range

            promptTextObject.SetActive(true); // Show the prompt text when the player enters the trigger area
        }
    }

    void OnTriggerExit2D(Collider2D other) // Check if the player exits the trigger area to hide the prompt
    {
        if (other.CompareTag("Player")) 
        {
            playerInRange = false; // Indicate the player is no longer in range

            promptTextObject.SetActive(false); // Hide the prompt text when the player exits the trigger area
        }
    }
}