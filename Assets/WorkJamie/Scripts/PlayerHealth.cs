using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;

    private PlayerHide playerHide;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        Health = 1;

        PlayerPrefs.SetString("LastPlayedScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        playerHide = GetComponent<PlayerHide>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.CompareTag("Enemy") && !playerHide.IsHiding())
        {
            Health--;

            if (Health <= 0)
            {
                PlayerDeath();
            }
        }
    }

    public void PlayerDeath()
    {
        isDead = true;

        if (animator != null)
        {
            animator.SetBool("IsDead", true);
        }
        Invoke(nameof(LoadGameOver), 1.5f);
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}