using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] public Slider musicVolumeSlider;
    [SerializeField] public Slider sfxVolumeSlider;

    void Start()
    {
        
    }

    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicVolumeSlider.value;
        SaveMusic();
    }

    public void ChangeSFXVolume()
    {
        AudioListener.volume = sfxVolumeSlider.value;
        SaveSFX();
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
    }
}
