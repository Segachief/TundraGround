using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour // This script was written by Jamie
// and then updated by SM hehe
{

    private LevelManager levelManager;

    void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    public void ButtonPressed(GameObject button)
    {
        if(button.name == "MainMenu")
        {
            levelManager.LoadMainMenu();
        }
        else if(button.name == "Retry")
        {   
            // LastPlayedScene is set in PlayerHealth on Start() so Retry
            // will always play the last level the player played. - Jamie

            // Updated to use LevelManager - SM
            SceneManager.LoadScene(PlayerPrefs.GetString("LastPlayedScene"));
            switch(PlayerPrefs.GetString("LastPlayedScene"))
            {
                case "Level1":
                levelManager.LoadLevel1();
                break;

                case "Level2":
                levelManager.LoadLevel2();
                break;

                case "Level3":
                levelManager.LoadLevel3();
                break;

                case "Level4":
                levelManager.LoadLevel4();
                break;

                case "Level5":
                levelManager.LoadLevel5();
                break;

                default:
                levelManager.LoadMainMenu();
                break;
            }
        }
        else
        {
            Debug.LogWarning("Unknown button pressed on GameOver Scene");
        }
    }
}
