using UnityEngine;

public class BearPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge; // Patrol Point
    [SerializeField] private Transform rightEdge; // Patrol Point
    [SerializeField] private Transform enemy; // Enemy
    [SerializeField] private float speed; // Speed of Enemy 
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField] private Animator anim;
    [SerializeField] private float idleDuration;
    [SerializeField] private Transform player;
    private PlayerHide playerHide;
    [SerializeField] private float chaseRange;
    private bool chasing;
    private float idleTimer;
    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float ChaseSpeed;
 


    private void Awake()
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        initScale = enemy.localScale;
        playerHide = player.GetComponent<PlayerHide>();
    }
    private void FixedUpdate()
    {
        Vector2 direction = movingLeft ? Vector2.left : Vector2.right;
        Vector2 origin = groundCheck.position + (Vector3)(direction * 0.5f);
        Debug.DrawRay(origin, Vector2.down * groundCheckDistance, Color.red);
        bool groundAhead = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);
        float distanceToPlayer = Vector2.Distance(enemy.position, player.position);
        float heightDifference = Mathf.Abs(player.position.y - enemy.position.y);
        if (distanceToPlayer < chaseRange && heightDifference < 1f && !playerHide.IsHiding())
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            if (movingLeft)
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
                MoveInDirection(-1);
            }
            else
            {
                if (enemy.position.x >= rightEdge.position.x)
                {
                    StopAndTurn();
                    return;
                }
                if (!groundAhead)
                {
                    StopAndTurn();
                    return;
                }
                MoveInDirection(1);
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("isWalking", false);
        idleTimer += Time.fixedDeltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
            idleTimer = 0;
        }
    } 

    private void StopAndTurn()
    {
        rb.linearVelocity = Vector2.zero;
        DirectionChange();
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("isWalking", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -_direction, initScale.y, initScale.z); // //Make enemy face direction
        rb.linearVelocity = new Vector2(_direction * speed, rb.linearVelocity.y); // Move in that direction
    }

    private void ChasePlayer()
    {
        anim.SetBool("isWalking", true);
        if (player.position.x > enemy.position.x) // Face the player
            enemy.localScale = new Vector3(-Mathf.Abs(initScale.x), initScale.y, initScale.z);
        else
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z);
        float direction = Mathf.Sign(player.position.x - enemy.position.x);
        Vector2 checkDirection = direction > 0 ? Vector2.right : Vector2.left; // Ground check in front of bear
        Vector2 origin = groundCheck.position + (Vector3)(checkDirection * 0.5f);
        bool groundAhead = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);
        if (!groundAhead) // Stop bear walking off edges
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = new Vector2(direction * ChaseSpeed, rb.linearVelocity.y); // Chase player
    }
}
