using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour /// Script written by Jamie - 
{
    public int Health;
    public KeyCode godToggleButton;
    public bool godModeState;
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
        if(!godModeState)
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
    }
    void Update()
    {
        // Toggles God Mode on Player when pressed
        if(Input.GetKeyDown(godToggleButton) && (godModeState == false))
        {
            godModeState = true;
        }
        else if(Input.GetKeyDown(godToggleButton) && (godModeState == true))
        {
            godModeState = false;
        }
    }

    public void PlayerDeath()
    {
        levelManager.LoadGameOver();
    }
}