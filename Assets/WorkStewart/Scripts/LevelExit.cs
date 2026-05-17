using UnityEngine;

public class LevelExit : MonoBehaviour
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
            levelManager.LoadEnding();
        }
    }
}