using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour // This script was written by Jamie
{
    
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(GameObject button)
    {
        if(button.name == "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if(button.name == "Retry")
        {   
            //LastPlayedScene is set in PlayerHealth on Start() so Retry will always play the last level the player played.
            SceneManager.LoadScene(PlayerPrefs.GetString("LastPlayedScene"));
        }

        else
        {
            Debug.LogWarning("Unkown button pressed on GameOver Scene");
        }
    }
}
