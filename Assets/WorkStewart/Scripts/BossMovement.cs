using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //SM
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rb;
    Animator myAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, 0f);

        //If boss is Moving
        myAnimator.SetBool("isIdle", false);
        myAnimator.SetBool("isMoving", true);
        myAnimator.SetBool("isAttacking", false);
        
        //else if boss is attacking
        myAnimator.SetBool("isIdle", false);
        myAnimator.SetBool("isMoving", false);
        myAnimator.SetBool("isAttacking", true);

        //Else (use Idle)
        myAnimator.SetBool("isIdle", true);
        myAnimator.SetBool("isMoving", false);
        myAnimator.SetBool("isAttacking", false);
    }

    void FlipSprite()
    {
        // Checks if player has any X-axis momentum
        // Epsilon is an alternative to 0, a float with a tiny value.
        // Movement may not always reach absolute 0 so this is a way to cover those
        // fringe cases (for example, value is within deadzone on a controller stick).
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            // Flips the sprite based on its velocity x movement
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}