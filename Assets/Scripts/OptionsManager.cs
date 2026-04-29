using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] public Slider musicVolumeSlider;

    void Start()
    {
        
    }

    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicVolumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }
}
