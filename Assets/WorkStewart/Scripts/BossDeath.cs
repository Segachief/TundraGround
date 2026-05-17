using UnityEngine;

public class BossDeath : MonoBehaviour
{
    // SM
    // An adapted version of EnemyHealth script for the Boss script
    // which destroys both the carrier of this script and the 'spirit'
    // enemy that attacks the player
    [SerializeField] int Health;
    public GameObject bossSpirit;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        bossSpirit = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
         if(Health <= 0)
         {
             audioManager.ForestSpiritSFX();
             Destroy(bossSpirit);
             Destroy(gameObject);
         }
    }
}
