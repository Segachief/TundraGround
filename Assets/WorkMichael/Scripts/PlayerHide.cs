using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool canHide = false;
    private bool isHiding = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.W))
        {
            ToggleHide();
        }
    }

    private void ToggleHide()
    {
        isHiding = !isHiding;
        if (isHiding)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            IgnoreEnemies(true);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            IgnoreEnemies(false);
        }
    }

    private void IgnoreEnemies(bool ignore)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
            if (enemyCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, enemyCollider, ignore);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HideSpot"))
        {
            canHide = false;
            if (isHiding)
            {
                ToggleHide();
            }
        }
    }

    public bool IsHiding()
    {
        return isHiding;
    }
}