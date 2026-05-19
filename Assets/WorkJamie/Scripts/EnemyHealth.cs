using UnityEngine;

public class EnemyHealth : MonoBehaviour // made by Jamie
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Health;
    public AudioSource EnemyDeathSFX;

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //EnemyDeathSFX.Play();
            Destroy(gameObject);
        }
    }
}
