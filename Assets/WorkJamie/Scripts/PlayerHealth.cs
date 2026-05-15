using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour /// Script written by Jamie - 
{
    public int Health;

    private PlayerHide playerHide;

    void Start()
    {
        Health = 1;

        PlayerPrefs.SetString("LastPlayedScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        playerHide = GetComponent<PlayerHide>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !playerHide.IsHiding())
        {
            Health--;

            if (Health <= 0)
            {
                Invoke(nameof(PlayerDeath), 1.5f);
            }

            return;
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }
}