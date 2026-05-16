using UnityEngine;
using TMPro;

public class BridgeBuilder : MonoBehaviour // Script by Michael Arthur
{
    public GameObject bridge;
    public GameObject promptTextObject;
    public TextMeshProUGUI promptText;
    public int woodCost = 10;
    private bool playerInRange;

    void Start()
    {
        bridge.SetActive(false);

        promptTextObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange)
        {
            promptText.text =
                "Press E to build bridge\n" +
                "Cost: " + woodCost + " Wood";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (InventoryManager.instance.Wood >= woodCost)
                {
                    InventoryManager.instance.AddWood(-woodCost);
                    bridge.SetActive(true);
                    promptTextObject.SetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            promptTextObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            promptTextObject.SetActive(false);
        }
    }
}