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
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        myAnimator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        IsAxeSwinging = myAnimator.GetBool("AxeSwing");

        if(Input.GetKeyDown(Axe_Button) && InventoryManager.instance.Inventory.Contains(axe) && playerHealth.Health > 0)
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

            case "Boss":
                EnemyKnockbackAlt(collision.gameObject);
                StartCoroutine(DamageFlashAlt(collision.gameObject));
                collision.gameObject.GetComponent<BossManagement>().health--;
                return;

            case "Skull":
                EnemyKnockbackAlt(collision.gameObject);
                StartCoroutine(DamageFlashAlt(collision.gameObject));
                collision.gameObject.GetComponent<BossDeath>().health--;
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
        Vector2 direction = (enemy.gameObject.transform.position - transform.position).normalized;
        
        

        enemy.GetComponentInParent<BearPatrol>().IsKnockedBack = true;
        enemy.GetComponentInParent<Rigidbody2D>().AddForce(direction * 0.55f,ForceMode2D.Impulse);
    }

    public IEnumerator DamageFlash(GameObject gameobj)
    {
        gameobj.GetComponentInParent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameobj.GetComponentInParent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator DamageFlashAlt(GameObject gameobj)
    {
        gameobj.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameobj.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void EnemyKnockbackAlt(GameObject enemy)
    {
        float knock_float = (enemy.gameObject.transform.position.x - transform.position.x);
        Vector2 knockback_vec = new Vector2(knock_float * 175, 0f);
        enemy.GetComponent<Rigidbody2D>().AddForce(knockback_vec);
    }
}
