using UnityEngine;

public class BossDeath : MonoBehaviour
{
    // SM
    // An adapted version of EnemyHealth script for the Boss script
    // which destroys both the carrier of this script and the 'spirit'
    // enemy that attacks the player
    public int health = 1;
    public GameObject bossSpirit;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
         if(health <= 0)
         {
            audioManager.ForestSpiritSFX();
            gameObject.SetActive(false);
            bossSpirit.SetActive(false);
         }
    }
}
