using UnityEngine;

public class PlayerHide : MonoBehaviour // Script by Michael Arthur
{
    private bool canHide = false; // Indicates if the player is in a hideable area
    private bool isHiding = false; // Indicates if the player is currently hiding
    private SpriteRenderer spriteRenderer; // Reference to the player's SpriteRenderer
    private Collider2D playerCollider; // Reference to the player's Collider2D

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        playerCollider = GetComponent<Collider2D>(); // Get the Collider2D component
    }

    void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.W)) // Check if the player can hide and if the 'W' key is pressed
        {
            ToggleHide(); // Toggle the hiding state
        }
    }

    private void ToggleHide()
    { // I had some help with ChatGPT with making the player semi transparent as i wasn't sure how to do that
        isHiding = !isHiding; // Toggle the hiding state
        if (isHiding) // If the player is now hiding make them semi transparent and ignore collisions with enemies
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            IgnoreEnemies(true);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            IgnoreEnemies(false);
        }
    }

    private void IgnoreEnemies(bool ignore)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all enemies in the scene
        foreach (GameObject enemy in enemies) // Loop through each enemy and ignore or re enable collisions based on the hiding state
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>(); // Get the Collider2D component of the enemy
            if (enemyCollider != null) // Check if the enemy has a Collider2D component
            {
                Physics2D.IgnoreCollision(playerCollider, enemyCollider, ignore); // Ignore or re enable collisions between the player and the enemy based on the hiding state
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // Check if the player enters a hideable area
    {
        if (other.CompareTag("HideSpot")) // Check if the collider belongs to a hide spot
        {
            canHide = true; // Allow the player to hide
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Check if the player exits a hideable area
    {
        if (other.CompareTag("HideSpot")) // Check if the collider belongs to a hide spot
        {
            canHide = false; // Disallow the player to hide
            if (isHiding) // If the player is currently hiding toggle it off when they exit the hide spot
            {
                ToggleHide(); // Toggle the hiding state off
            }
        }
    }

    public bool IsHiding() // Method to check if the player is currently hiding
    {
        return isHiding; // Return the current hiding state
    }
}