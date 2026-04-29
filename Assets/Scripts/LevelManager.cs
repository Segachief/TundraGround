using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    string currentScene = "";
    private AudioManager audioManager;
    

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void LoadMainMenu()
    {
        audioManager.StartFadeMusicOut(currentScene);

        currentScene = "MainMenu";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StopMusic();
        audioManager.StartMainMenuMusic();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadGameOver()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        
        currentScene = "GameOver";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StopMusic();
        audioManager.StartGameOverMusic();
        audioManager.StartFadeMusicIn(currentScene);
    }

    public void LoadOptions()
    {
        audioManager.MenuButtonSFX();
        currentScene = "Options";
        ScreenFader.Instance.FadeToScene(currentScene);
    }

    public void LoadControls()
    {
        currentScene = "Controls";
        ScreenFader.Instance.FadeToScene("Controls");
    }    
    
    public void LoadLevel1()
    {
        audioManager.StartFadeMusicOut(currentScene);
        //scoreKeeper.SetHighScore();
        //scoreKeeper.ResetScore();
        
        currentScene = "Level1";
        ScreenFader.Instance.FadeToScene(currentScene);
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
        audioManager.StopMusic();
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
