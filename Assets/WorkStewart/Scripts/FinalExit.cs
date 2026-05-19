using UnityEngine;

public class FinalExit : MonoBehaviour
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