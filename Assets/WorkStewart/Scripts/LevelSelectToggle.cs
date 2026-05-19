using UnityEngine;

public class LevelSelectToggle : MonoBehaviour
{
    //SM
    public KeyCode levelSelectButton;
    public bool levelSelectState;
    private GameObject levelSelect;

    void Start()
    {
        levelSelect = GameObject.Find("MenuCanvas");
        levelSelect = levelSelect.transform.Find("LevelSelect").gameObject;
        levelSelectState = levelSelect.activeSelf;
    }

    void Update()
    {
        if(Input.GetKeyDown(levelSelectButton) && (levelSelectState = false))
        {
            levelSelect.SetActive(levelSelect.activeSelf);
        }
        else if(Input.GetKeyDown(levelSelectButton) && (levelSelectState = true))
        {
            levelSelect.SetActive(!levelSelect.activeSelf);
        }
    }
}
