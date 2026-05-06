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
    private float idleTimer;
 

    private void Awake()
    {
        initScale = enemy.localScale;
        
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("isWalking", false );
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int  _direction)
{
        idleTimer = 0;
    anim.SetBool("isWalking", true );
    //Make enemy face direction
    enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -_direction, initScale.y, initScale.z);

    // Move in that direction
    enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
}

}
  