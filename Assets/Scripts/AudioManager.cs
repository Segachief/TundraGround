using UnityEngine;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource title;
    [SerializeField] private AudioSource mainMenu;
    [SerializeField] private AudioSource level1;
    [SerializeField] private AudioSource level2;
    [SerializeField] private AudioSource level3;
    [SerializeField] private AudioSource level4;
    [SerializeField] private AudioSource level5;
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private AudioSource levelComplete;
    [SerializeField] private float fadeTimerInterval = 0.001f;

    private string songName = "";
    private bool titlePlaying = false;
    private bool mainMenuPlaying = false;
    private bool level1Playing = false;
    private bool level2Playing = false;
    private bool level3Playing = false;
    private bool level4Playing = false;
    private bool level5Playing = false;
    private bool gameOverPlaying = false;
    private bool levelCompletePlaying = false;

    // SFX (add as needed)
    [Header("PlayerAttack")]
    [SerializeField] private AudioSource playerAttack;

    // In this, I've set up a 'clips' variable that can be used to
    // play the SFX with randomised pitches, method at the bottom
    [Header("BearAttack")]
    [SerializeField] private AudioSource bearAttack;
    [SerializeField] private AudioClip[] bearAttackClips;

    [Header("CraftingUI")]
    [SerializeField] private AudioSource openCraftingUI;
    [SerializeField] private AudioSource closeCraftingUI;

    // This is the AudioManager instance that will exist throughout
    // the game's runtime
    private static AudioManager instance;

    void Awake()
    {
        // If no AudioManager exists, this creates one
        // It also ensures there is never more than one
        if(AudioManager.instance == null)
        {
            DontDestroyOnLoad(this);
            AudioManager.instance = this;
        }
        else
        {
            Destroy (this.gameObject);
        }
    }

    // Stops all music in preparation for the next track or for silence
    public void StopMusic()
    {
        title.Stop(); titlePlaying = false;
        mainMenu.Stop(); mainMenuPlaying = false;
        level1.Stop(); level1Playing = false;
        level2.Stop(); level2Playing = false;
        level3.Stop(); level3Playing = false;
        level4.Stop(); level4Playing = false;
        level5.Stop(); level5Playing = false;
        gameOver.Stop(); gameOverPlaying = false;
        levelComplete.Stop(); levelCompletePlaying = false;
    }

    public void StartTitleMusic()
    {
        if (!titlePlaying)
        {
            StopMusic();
            title.Play(); titlePlaying = true;
            title.volume = 0.1f;
        }
    }

    public void StartMainMenuMusic()
    {
        if (!mainMenuPlaying)
        {
            StopMusic();
            mainMenu.Play(); mainMenuPlaying = true;
            mainMenu.volume = 0.1f;
        }
    }

    public void StartLevel1Music()
    {
        if (!level1Playing)
        {
            StopMusic();
            level1.Play(); level1Playing = true;
            level1.volume = 0.1f;
        }
    }

    public void StartLevel2Music()
    {
        if (!level2Playing)
        {
            StopMusic();
            level2.Play(); level2Playing = true;
            level2.volume = 0.1f;
        }
    }

    public void StartLevel3Music()
    {
        if (!level3Playing)
        {
            StopMusic();
            level3.Play(); level3Playing = true;
            level3.volume = 0.1f;
        }
    }

    public void StartLevel4Music()
    {
        if (!level4Playing)
        {
            StopMusic();
            level4.Play(); level4Playing = true;
            level4.volume = 0.1f;
        }
    }

    public void StartLevel5Music()
    {
        if (!level5Playing)
        {
            StopMusic();
            level5.Play(); level5Playing = true;
            level5.volume = 0.1f;
        }
    }

    public void StartGameOverMusic()
    {
        if (!gameOverPlaying)
        {
            StopMusic();
            gameOver.Play(); gameOverPlaying = true;
            gameOver.volume = 0.1f;
        }
    }

    public void StartLevelCompleteMusic()
    {
        if (!levelCompletePlaying)
        {
            StopMusic();
            levelComplete.Play(); levelCompletePlaying = true;
            levelComplete.volume = 0.1f;
        }
    }

    // These co-routines handle audio fade; they can be called from other classes
    // and require the song title to be passed in (Example: "MainMenu", "Level1", etc.)
    public void StartFadeMusicIn(string songName)
    { 
        StartCoroutine(FadeMusic("FadeIn", songName));
    }
    public void StartFadeMusicOut(string songName)
    {
        StartCoroutine(FadeMusic("FadeOut", songName));
    }

    // This goes through and sets the FadeIn/FadeOut for the passed track
    // There may be a cleaner way to implement this if it can determine
    // which track is playing instead of having it passed explicitly so
    // potential for code cleanup here.
    private IEnumerator FadeMusic(string fade, string songName)
    {
        if (fade == "FadeIn")
        {
            switch(songName)
            {
                case "Title":
                while (title.volume > 0)
                {
                    title.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "MainMenu":
                while (mainMenu.volume > 0)
                {
                    mainMenu.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level1":
                while (level1.volume > 0)
                {
                    level1.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level2":
                while (level2.volume > 0)
                {
                    level2.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level3":
                while (level3.volume > 0)
                {
                    level3.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level4":
                while (level4.volume > 0)
                {
                    level4.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level5":
                while (level5.volume > 0)
                {
                    level5.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "GameOver":
                while (gameOver.volume > 0)
                {
                    gameOver.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "LevelComplete":
                while (levelComplete.volume > 0)
                {
                    levelComplete.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;
            }
        }
        else if (fade == "FadeOut")
        {
            switch(songName)
            {
                case "Title":
                while (title.volume < 0.1f)
                {
                    title.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "MainMenu":
                while (mainMenu.volume < 0.1f)
                {
                    mainMenu.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level1":
                while (level1.volume < 0.1f)
                {
                    level1.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level2":
                while (level2.volume < 0.1f)
                {
                    level2.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level3":
                while (level3.volume < 0.1f)
                {
                    level3.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level4":
                while (level4.volume < 0.1f)
                {
                    level4.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level5":
                while (level5.volume < 0.1f)
                {
                    level5.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "GameOver":
                while (gameOver.volume < 0.1f)
                {
                    gameOver.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "LevelComplete":
                while (levelComplete.volume < 0.1f)
                {
                    levelComplete.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;
            }
        }
    }

    // This method gives the option to play SFX with a random pitch
    // to avoid repetition
    public void PlayRandomPitch()
    {
        int clip = UnityEngine.Random.Range(0, bearAttackClips.Length);
        bearAttack.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        bearAttack.PlayOneShot(bearAttackClips[clip]);
    }
}
