using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] bool hasTriggered;
    [SerializeField] Vector3 placementDebug; //Used for adjusting cutscene movement only
    [SerializeField] string identifier = "";
    
    Vector3 movePlayer;
    private PlayerMovement player;
    private GameObject playerGO;

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

    void cutscene1A(){
		
            //Lock player movement
            //Pan/Lock Camera
            //Play transform effect and hide regular stag, make actual boss appear in its place
            audioManager.StartLevel5Music();
            //Unlock player movement & activate boss
    }
}
