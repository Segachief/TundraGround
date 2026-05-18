using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelTransition : MonoBehaviour // Script by Michael Arthur 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) // This method is called when a collision occurs with the Player object
    {
        if (collision.gameObject.name == "Player") // Check if the colliding object is the player
        {
            SceneManager.LoadScene("Level3"); // Load the next scene named Level 3
        }
    }
}
