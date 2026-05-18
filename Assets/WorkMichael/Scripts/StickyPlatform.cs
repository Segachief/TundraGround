using UnityEngine;

public class StickyPlatform : MonoBehaviour // Script by Michael Arthur
{
    private void OnTriggerEnter2D(Collider2D collision) // When the player enters the trigger area of the platform it will set the players parent to the platform so that it moves with it
    {
        if (collision.CompareTag("Player")) // Check if the colliding object has the tag Player
        {
            collision.transform.SetParent(transform); // Set the parent of the colliding object to the platform
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // When the player exits the trigger area of the platform it will set the players parent to null so that it no longer moves with the platform
    {
        if (collision.CompareTag("Player")) // Check if the colliding object has the tag Player
        {
            collision.transform.SetParent(null); // Set the parent of the colliding object to null so that it no longer moves with the platform
        }
    }
}