using UnityEngine;

public class EnemyHealth : MonoBehaviour // made by Jamie
{
    public int Health;
    public bool hasDied = false;

    // Added audio manager ref - SM
    private AudioManager audioManager;
    
    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    // Updated to deactivate object instead of destroy to avoid a crash
    // where damage flash can be trying to refer to the destroyed object. - SM 
    void Update()
    {
        if(Health <= 0 && hasDied == false)
        {
            hasDied = true;
            audioManager.EnemyDeathSFX();
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
            //Destroy(gameObject);
        }
    }
}
