using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour /// Script written by Jamie - 
{
    public int Health;
    void Start()
    {
        Health = 1;
        PlayerPrefs.SetString("LastPlayedScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save(); // Ensures it writes to disk
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Health--;
            return;
        }
    }

    void PlayerDeath()
    {
        
        
        SceneManager.LoadScene("GameOver");
    }
}
