using System.Collections;
using UnityEngine;

public class BearPatrol : MonoBehaviour // Script by Michael Arthur
{
    [SerializeField] private Transform leftEdge; // Patrol Point left
    [SerializeField] private Transform rightEdge; // Patrol Point right
    [SerializeField] private Transform enemy; // Enemy
    [SerializeField] private float speed; // Speed of Enemy 
    private Vector3 initScale; // Initial scale of Enemy used for flipping Enemy when changing direction
    private bool movingLeft; // A bool to check if enemy is moving left or right
    [SerializeField] private Animator anim; // Animator for Enemy
    [SerializeField] private float idleDuration; // Time enemy waits at patrol points
    [SerializeField] private Transform player; // Player
    private PlayerHide playerHide; // Reference to PlayerHide script
    [SerializeField] private float chaseRange; // Distance at which enemy starts chasing player
    private bool chasing; // A bool to check enemy is currently chasing the player
    private float idleTimer; // Timer to track how long enemy has been idle
    private Rigidbody2D rb; // Rigidbody of the enemy for movement
    [SerializeField] private Transform groundCheck; // To check if there is ground ahead
    [SerializeField] private float groundCheckDistance; // Distance for ground check raycast
    [SerializeField] private LayerMask groundLayer; // Layer to specify what is considered ground for the raycast
    [SerializeField] private float ChaseSpeed; // Speed of enemy when chasing the player
    public bool IsKnockedBack = false;


    private void Awake()
    {
       
        rb = enemy.GetComponent<Rigidbody2D>(); // Get Rigidbody component from enemy
        initScale = enemy.localScale; // Get initial scale of enemy
        playerHide = player.GetComponent<PlayerHide>(); // Get reference to PlayerHide script on player
    }
    private void FixedUpdate() // I used fixed update for better physics 
    {
        if (IsKnockedBack)
        {
            StartCoroutine(RecoverFromKnockBack());
            return;
        }
        Vector2 direction = movingLeft ? Vector2.left : Vector2.right; // Direction enemy is moving in
        Vector2 origin = groundCheck.position + (Vector3)(direction * 0.5f); // Ground check raycast in front of enemy 
        Debug.DrawRay(origin, Vector2.down * groundCheckDistance, Color.red); // Debug for raycast 
        bool groundAhead = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer); // Check if there is ground ahead of enemy to prevent walking off edges
        float distanceToPlayer = Vector2.Distance(enemy.position, player.position); // Calculate distance from enemy to player
        float heightDifference = Mathf.Abs(player.position.y - enemy.position.y); // Calculate height difference between enemy and player to prevent chasing if player is on a different height 
        if (distanceToPlayer < chaseRange && heightDifference < 1f && !playerHide.IsHiding()) // Checks if player is within chase range on a similar height and not hiding
        {
            chasing = true; // Start chasing player
        }
        else
        {
            chasing = false; // Stop chasing player
        }

        if (chasing) // If enemy is chasing player
        {
            ChasePlayer(); // Call method to chase player
        }
        else
        {
            if (movingLeft) // If enemy is moving left check if it has reached left patrol point and if there is no ground ahead
            {
                if (enemy.position.x <= leftEdge.position.x) 
                {
                    StopAndTurn();
                    return;
                }
                if (!groundAhead) 
                {
                    StopAndTurn();
                    return;
                }
                MoveInDirection(-1); // Move left
            }
            else
            {
                if (enemy.position.x >= rightEdge.position.x) // If enemy is moving right check if it has reached right patrol point and if there is no ground ahead
                {
                    StopAndTurn();
                    return;
                }
                if (!groundAhead)
                {
                    StopAndTurn();
                    return;
                }
                MoveInDirection(1); // Move right
            }
        }
    }

    private void DirectionChange() // Method to handle enemy stopping and turning at patrol points
    {
        anim.SetBool("isWalking", false); // Set walking animation to false when enemy stops to turn
        idleTimer += Time.fixedDeltaTime; // Increment idle timer while enemy is idle
        if (idleTimer > idleDuration) // If enemy has been idle for longer than idle duration, change direction
        {
            movingLeft = !movingLeft; 
            idleTimer = 0; // Reset idle timer
        }
    } 

    private void StopAndTurn() // Method to stop enemy movement and call direction change method
    {
        //
        //
        //rb.linearVelocity = Vector2.zero;
        DirectionChange();
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0; // Reset idle timer when enemy starts moving again
        anim.SetBool("isWalking", true); // Set walking animation to true when enemy is moving
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -_direction, initScale.y, initScale.z); // Make enemy face direction
        rb.linearVelocity = new Vector2(_direction * speed, rb.linearVelocity.y); // Move in that direction
    }

    private void ChasePlayer() // I had to use some ChatGPT help for this method to get the ground check working properly while chasing the player. Because the bear was floating in the air when it reached edges while chasing the player
    { // I also used some ChatGPT to help me with the Math of some of this code 
        anim.SetBool("isWalking", true); // Set walking animation to true when chasing player
        if (player.position.x > enemy.position.x) // Face the player
            enemy.localScale = new Vector3(-Mathf.Abs(initScale.x), initScale.y, initScale.z); // Face right
        else
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z); // Face left
        float direction = Mathf.Sign(player.position.x - enemy.position.x); 
        Vector2 checkDirection = direction > 0 ? Vector2.right : Vector2.left; // Ground check in front of bear
        Vector2 origin = groundCheck.position + (Vector3)(checkDirection * 0.5f); // Ground check raycast in front of bear while chasing player
        bool groundAhead = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer); // Check if there is ground ahead of bear while chasing player to prevent walking off edges
        if (!groundAhead) // Stop bear walking off edges
        {
            //rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = new Vector2(direction * ChaseSpeed, rb.linearVelocity.y); // Chase player
    }


    public IEnumerator RecoverFromKnockBack()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        IsKnockedBack = false;
    }
}
