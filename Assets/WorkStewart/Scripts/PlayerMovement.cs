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
    public Sprite spr;
    Vector2 down_dir = new Vector2(0, -1);
    PlayerInput playerInput;
    bool IsGrounded;
    void Start()
    {
        IsGrounded = true;
        playerInput = GetComponent<PlayerInput>();
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
                rb.gravityScale = 1.9f;
            }
            else if (inventoryManager.Wood >= 10)
            {
                rb.gravityScale = 2.1f;
            }
            else if (inventoryManager.Wood >= 20)
            {
                rb.gravityScale = 2.3f;
            }
        }



        Run();
        FlipSprite();
        ClimbLadder();
        CheckForAirTime();
        AmIDead();
        //to stop player from super-jumping

        if (IsGrounded)
        {
            playerInput.actions.FindAction("Jump").Enable();
        }
        else
        {
            playerInput.actions.FindAction("Jump").Disable();
        }
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        // Checks if the player is touching the Ground layer
        // If not, prevents the use of Jump
        if (value.isPressed &&
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
        if (hasHorizontalSpeed && !myAnimator.GetBool("IsJumping"))
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
        if (hasHorizontalSpeed)
        {
            // Flips the sprite based on its velocity x movement
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetBool("isClimbing", true);
            }
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

    //these functions were made by Jamie - 
    void CheckForAirTime()
    {
        if (RayFromPlayerCentre(Vector2.down, 1.1f))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

        myAnimator.SetBool("IsJumping", !IsGrounded);
        
    }

    bool RayFromPlayerCentre(Vector2 dir,float length)
    {
        Vector2 player_centre = new Vector2(transform.position.x, transform.position.y + 1);
        bool hit = Physics2D.Raycast(player_centre, dir, length,LayerMask.GetMask("Ground"));
        return hit;
    }


    void AmIDead()
    {
        if(GetComponent<PlayerHealth>().Health <= 0)
        {
            //if the animator wont play IsDead unless every other bool is false
            //if theres a better way of doing this i dont know it clearly - J
            myAnimator.SetBool("isRunning",false);
            myAnimator.SetBool("IsJumping", false);
            myAnimator.SetBool("AxeSwing", false);
            myAnimator.SetTrigger("IsDead");
        }
    }
}