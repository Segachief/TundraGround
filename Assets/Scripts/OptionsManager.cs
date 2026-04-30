using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public AudioManager audioManager;

     void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }


    void Start()
    {
        // Sets the slider starting state to match current volume
        musicVolumeSlider.value = audioManager.musicVolume;
        sfxVolumeSlider.value = audioManager.sfxVolume;
    }

    public void ChangeMusicVolume()
    {
        // AudioListener dynamically changes the volume as you adjust slider
        // Otherwise, music volume doesn't update until you leave Options
        //AudioListener.volume = musicVolumeSlider.value;
        audioManager.musicVolume = musicVolumeSlider.value;
        SaveMusic();
    }

    public void ChangeSFXVolume()
    {
        audioManager.sfxVolume = sfxVolumeSlider.value;
        SaveSFX();
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
        //audioManager.UpdateSFXVolume(sfxVolumeSlider.value);
    }
}
