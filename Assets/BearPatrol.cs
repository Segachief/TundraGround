using UnityEngine;

public class BearPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge; // Patrol Point
    [SerializeField] private Transform rightEdge; // Patrol Point
    [SerializeField] private Transform enemy; // Enemy
    [SerializeField] private float speed; // Speed of Enemy 
    private Vector3 initScale;
    private bool movingLeft;
    private Animator anim;

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
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int  _direction)
{
    //Make enemy face direction
    enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -_direction, initScale.y, initScale.z);

    // Move in that direction
    enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
}

}
  