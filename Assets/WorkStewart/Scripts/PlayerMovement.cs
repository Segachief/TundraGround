using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpSpeed = 11f;
    [SerializeField] float climbSpeed = 4;

    Vector2 moveInput;
    Rigidbody2D rb;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    float playerGravity;
    InventoryManager inventoryManager;
    float startingGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        playerGravity = rb.gravityScale;
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    void FixedUpdate()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = 0f;
        }
        else
        {
            // Decreases jump height in stages; scaling it per unit of wood
            // may make it difficult to design obstacles around vs. having
            // clear-cut jump heights.
            if (inventoryManager.Wood < 10)
            {
                rb.gravityScale = 2f;
            }
            else if (inventoryManager.Wood >= 10)
            {
                rb.gravityScale = 3f;
            }
            else if (inventoryManager.Wood >= 20)
            {
                rb.gravityScale = 4f;
            }
        }
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        // Checks if the player is touching the Ground layer
        // If not, prevents the use of Jump
        if(value.isPressed && 
            myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
            || myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;

        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if(hasHorizontalSpeed)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void FlipSprite()
    {
        // Checks if player has any X-axis momentum
        // Epsilon is an alternative to 0, a float with a tiny value.
        // Movement may not always reach absolute 0 so this is a way to cover those
        // fringe cases (for example, value is within deadzone on a controller stick).
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if(hasHorizontalSpeed)
        {
            // Flips the sprite based on its velocity x movement
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if(myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            // Prevents slide of player from gravity during climb
            // If we want the player to gradually slide down a tree, then this
            // can be removed or a check for tree/surface made to distinguish
            Vector2 climbVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * climbSpeed);
            rb.linearVelocity = climbVelocity;

            // May be good to add an idle anim for being on a climbable surface
            // but not moving up or down; uses regular standing idle currently
            bool hasVerticalSpeed = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", hasVerticalSpeed);
        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
        }
    }
}
