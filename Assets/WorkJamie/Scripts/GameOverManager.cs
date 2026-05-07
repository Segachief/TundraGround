using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
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
            SceneManager.LoadScene(PlayerPrefs.GetString("LastPlayedScene"));
        }
    }
}
