using UnityEngine;

public class WoodScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb2d;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        Vector2 spawnVector = new Vector2(Random.Range(-10f,10f),Random.Range(8f,12f));
        rb2d.AddForce(spawnVector);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            InventoryManager.instance.AddWood(10);
            Destroy(this.gameObject);
        }
    }


    
}
