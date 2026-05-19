using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelTransition : MonoBehaviour // Script by Michael Arthur 
{
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) // This method is called when a collision occurs with the Player object
    {
        if (collision.gameObject.name == "Player") // Check if the colliding object is the player
        {
            levelManager.LoadLevel4();
        }
    }
}
