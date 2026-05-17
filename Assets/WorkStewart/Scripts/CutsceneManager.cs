using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    //SM
    [SerializeField] bool hasTriggered;
    [SerializeField] Vector3 placementDebug; //Used for adjusting cutscene movement only
    [SerializeField] string identifier = "";
    
    Vector3 movePlayer;
    private PlayerMovement player;
    private GameObject playerGO;

    private GameObject boss;
    private GameObject preBoss;

    public Canvas canvas;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasTriggered)
        {
            player = FindFirstObjectByType<PlayerMovement>();
            playerGO = GameObject.Find("Player");
            preBoss = GameObject.Find("PreBoss");
            boss = GameObject.Find("Boss");

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
        preBoss.SetActive(false);
        boss.SetActive(true);
        audioManager.ForestSpiritSFX();
    }
}
