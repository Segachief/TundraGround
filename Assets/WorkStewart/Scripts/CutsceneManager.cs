using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    //SM
    [SerializeField] bool hasTriggered = false;
    [SerializeField] Vector3 placementDebug; //Used for adjusting cutscene movement only
    [SerializeField] string identifier = "";
    
    public GameObject boss;
    public GameObject preBoss;
    public GameObject snowEffect;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasTriggered)
        {
            hasTriggered = true;

            switch(identifier)
            {
                case "1A":
                cutscene1A();
                break;

                case "1B":
                break;

                case "1C":
                break;

                default:
                break;
            }
        }
    }

    void cutscene1A()
    {
        snowEffect.SetActive(true);
        preBoss.SetActive(false);
        boss.SetActive(true);
        audioManager.ForestSpiritSFX();
    }
}
