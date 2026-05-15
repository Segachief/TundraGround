using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class PlayerHide : MonoBehaviour
{
    private bool canHide = false;
    private bool isHiding = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
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
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
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
            if (isHiding) ToggleHide();
        }
    }

    public bool IsHiding()
    {
        return isHiding;
    }
}


