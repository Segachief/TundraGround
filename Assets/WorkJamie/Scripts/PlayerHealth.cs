using System.Collections;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Health--;
            return;
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }
}
