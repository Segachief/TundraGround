using System.Collections;
using System.Linq;
using UnityEngine;

public class AxeSwingingScript : MonoBehaviour // This script was written by Jamie - 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItemData axe;
    public KeyCode Axe_Button;
    Animator myAnimator;
    private bool IsAxeSwinging;
    // Update is called once per frame
    private void Awake()
    {
        myAnimator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        IsAxeSwinging = myAnimator.GetBool("AxeSwing");

        if(Input.GetKeyDown(Axe_Button) && InventoryManager.instance.Inventory.Contains(axe))
        {
            myAnimator.SetTrigger("AxeSwing");
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "tree":
                collision.gameObject.GetComponent<InteractableBehaviour>().DestroyTree();
                return;

            case "Enemy":
                EnemyKnockback(collision.gameObject);
                StartCoroutine(DamageFlash(collision.gameObject));
                collision.gameObject.GetComponentInParent<EnemyHealth>().Health--;
                return;
        }

    }

    public void EnableAxeHitbox()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableAxeHitbox()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void EnemyKnockback(GameObject enemy)
    {
        float knock_float = (enemy.gameObject.transform.position.x - transform.position.x);
        Vector2 knockback_vec = new Vector2(knock_float * 175, 0f);

        enemy.GetComponentInParent<Rigidbody2D>().AddForce(knockback_vec);
    }

    public IEnumerator DamageFlash(GameObject gameobj)
    {
        gameobj.GetComponentInParent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameobj.GetComponentInParent<SpriteRenderer>().color = Color.white;
        
    }
}
