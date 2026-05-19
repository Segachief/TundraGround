using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour /// Script written by Jamie - 
{
    public int Health;
    private PlayerHide playerHide;
    private LevelManager levelManager;

void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void Start()
    {
        Health = 1;

        PlayerPrefs.SetString("LastPlayedScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        playerHide = GetComponent<PlayerHide>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !playerHide.IsHiding())
        {
            Health--;
            return;
        }
        else if (collision.gameObject.tag == "Boss")
        {
            Health--;
            return;
        }
    }

    public void PlayerDeath()
    {
        levelManager.LoadGameOver();
    }
}