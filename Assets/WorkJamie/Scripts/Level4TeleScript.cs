using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4TeleScript : MonoBehaviour
{
    private LevelManager levelManager;

 void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            levelManager.LoadLevel5();
        }
    }
}
