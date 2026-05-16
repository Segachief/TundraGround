using UnityEngine;

public class BossDeath : MonoBehaviour
{
    // SM
    // An adapted version of EnemyHealth script for the Boss script
    // which destroys both the carrier of this script and the 'spirit'
    // enemy that attacks the player
    public int Health;
    public AudioSource EnemyDeathSFX;
    public GameObject bossSpirit;

    void Awake()
    {
        bossSpirit = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            EnemyDeathSFX.Play();
            Destroy(bossSpirit);
            Destroy(gameObject);
        }
    }
}
