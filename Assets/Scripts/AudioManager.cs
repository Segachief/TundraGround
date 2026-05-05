using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

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

    [Header("SFX")]
    [SerializeField] private AudioSource playerAttack;
    [SerializeField] private AudioSource menuChoiceUI;
    [SerializeField] private AudioSource bearAttack;
    [SerializeField] private AudioClip[] bearAttackClips;
    [SerializeField] private AudioSource openCraftingUI;
    [SerializeField] private AudioSource closeCraftingUI;

    [SerializeField] private float fadeTimerInterval = 0.001f;
    public float musicVolume = 0.1f;
    public float sfxVolume = 0.1f;

    private string songName = "";
    public bool titlePlaying = false;
    public bool mainMenuPlaying = false;
    public bool level1Playing = false;
    public bool level2Playing = false;
    public bool level3Playing = false;
    public bool level4Playing = false;
    public bool level5Playing = false;
    public bool gameOverPlaying = false;
    public bool levelCompletePlaying = false;



    // Note: This object is intended to be used as a Singleton.
    // That means it's generated once, and then kept alive (not destroyed)
    // when moving between scenes. Avoid adding it to other scenes other
    // than the game's starting screen (currently MainMenu); access the
    // other scenes via the Level Select to avoid audio issues/crashes.

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

            //Update to Title when moving Audio Manager to title screen
            mainMenu.Play(); mainMenuPlaying = true;
        }
        else
        {
            Destroy (this.gameObject);
        }
    }

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            // Default if there is no saved audio preference
            PlayerPrefs.SetFloat("musicVolume", 0.1f);
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            // Loads previously set audio setting
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
        }

        if(!PlayerPrefs.HasKey("sfxVolume"))
        {
            // Default if there is no saved audio preference
            PlayerPrefs.SetFloat("sfxVolume", 0.1f);
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            // Loads previously set audio setting
            PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
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

    public void UpdateSFXVolume(float newSFXVolume)
    {
        playerAttack.volume = newSFXVolume;
        menuChoiceUI.volume = newSFXVolume;
    }

    public void MenuButtonSFX()
    {
        menuChoiceUI.Play();
        menuChoiceUI.volume = sfxVolume;
    }

    public void StartTitleMusic()
    {
        if (!titlePlaying)
        {
            title.Play(); titlePlaying = true;
        }
    }

    public void StartMainMenuMusic()
    {
        if (!mainMenuPlaying)
        {
            mainMenu.Play(); mainMenuPlaying = true;
        }
    }

    public void StartGameOverMusic()
    {
        if (!gameOverPlaying)
        {
            gameOver.Play(); gameOverPlaying = true;
        }
    }

    public void StartLevelCompleteMusic()
    {
        if (!levelCompletePlaying)
        {
            levelComplete.Play(); levelCompletePlaying = true;
        }
    }

    public void StartLevel1Music()
    {
        if (!level1Playing)
        {
            level1.Play(); level1Playing = true;
        }
    }

    public void StartLevel2Music()
    {
        if (!level2Playing)
        {
            level2.Play(); level2Playing = true;
        }
    }

    public void StartLevel3Music()
    {
        if (!level3Playing)
        {
            level3.Play(); level3Playing = true;
        }
    }

    public void StartLevel4Music()
    {
        if (!level4Playing)
        {
            level4.Play(); level4Playing = true;
        }
    }

    public void StartLevel5Music()
    {
        if (!level5Playing)
        {
            level5.Play(); level5Playing = true;
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
                while (title.volume < musicVolume)
                {
                    title.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "MainMenu":
                while (mainMenu.volume < musicVolume)
                {
                    mainMenu.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level1":
                case "DebugTommy":
                while (level1.volume < musicVolume)
                {
                    level1.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level2":
                case "DebugMichael":
                while (level2.volume < musicVolume)
                {
                    level2.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level3":
                case "DebugCalum":
                while (level3.volume < musicVolume)
                {
                    level3.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level4":
                case "DebugJamie":
                while (level4.volume < musicVolume)
                {
                    level4.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "Level5":
                case "DebugStewart":
                while (level5.volume < musicVolume)
                {
                    level5.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "GameOver":
                while (gameOver.volume < musicVolume)
                {
                    gameOver.volume += 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                break;

                case "LevelComplete":
                while (levelComplete.volume < musicVolume)
                {
                    levelComplete.volume += 0.0001f;
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
                while (title.volume > 0)
                {
                    title.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                title.Stop(); titlePlaying = false;
                break;

                case "MainMenu":
                while (mainMenu.volume > 0)
                {
                    mainMenu.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                mainMenu.Stop(); mainMenuPlaying = false;
                break;

                case "Level1":
                case "DebugTommy":
                while (level1.volume > 0)
                {
                    level1.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                level1.Stop(); level1Playing = false;
                break;

                case "Level2":
                case "DebugMichael":
                while (level2.volume > 0)
                {
                    level2.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }        
                level2.Stop(); level2Playing = false;
                break;

                case "Level3":
                case "DebugCalum":
                while (level3.volume > 0)
                {
                    level3.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                level3.Stop(); level3Playing = false;
                break;

                case "Level4":
                case "DebugJamie":
                while (level4.volume > 0)
                {
                    level4.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }        
                level4.Stop(); level4Playing = false;
                break;

                case "Level5":
                case "DebugStewart":
                while (level5.volume > 0)
                {
                    level5.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }   
                level5.Stop(); level5Playing = false;
                break;

                case "GameOver":
                while (gameOver.volume > 0)
                {
                    gameOver.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }            
                gameOver.Stop(); gameOverPlaying = false;
                break;

                case "LevelComplete":
                while (levelComplete.volume > 0)
                {
                    levelComplete.volume -= 0.0001f;
                    yield return new WaitForSeconds(fadeTimerInterval);
                }
                levelComplete.Stop(); levelCompletePlaying = false;
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
