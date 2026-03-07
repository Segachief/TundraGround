using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    string currentScene = "";
    private static LevelManager instance;
    private AudioManager audioManager;
    

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();

        // If no LevelManager exists, this creates one
        // It also ensures there is never more than one
        if(LevelManager.instance == null)
        {
            DontDestroyOnLoad(this);
            LevelManager.instance = this;
        }
        else
        {
            Destroy (this.gameObject);
        }
    }

    public void LoadMainMenu()
    {
        audioManager.StartFadeMusicOut(currentScene);

        currentScene = "MainMenu";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartTitleMusic();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadGameOver()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        
        currentScene = "GameOver";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartGameOverMusic();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadControls()
    {
        ScreenFader.Instance.FadeToScene("Controls");
    }
    
    public void LoadLevel1()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level1";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel1Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadLevel2()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level2";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel2Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadLevel3()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level3";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel3Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadLevel4()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level4";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel4Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadLevel5()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level5";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel5Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadDebugCalum()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "DebugCalum";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel3Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadDebugJamie()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "DebugJamie";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel4Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadDebugMichael()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "DebugMichael";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel2Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadDebugStewart()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "DebugStewart";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel5Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadDebugTommy()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "DebugTommy";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StartLevel1Music();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
