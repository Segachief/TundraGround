using UnityEngine;

public class Level3Exit : MonoBehaviour
{
    [SerializeField] bool hasTriggered;
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasTriggered)
        {
            levelManager.LoadLevel4();
        }
    }
}