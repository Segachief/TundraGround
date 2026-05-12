using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{//Calum Yule
    
    public float speed;
    public bool chase = false;
    public bool squawking = false;
    public Transform startingPoint;
    private CircleCollider2D circleCollider;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (chase==true)
            Chase();
        else
            ReturnStartPoint();
        Flip();
    }

    //controls crow chase mechanics
    private void Chase()
    {
        //crow will target player and move towards them
        transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // if crow is near player, chase is paused and squawk is activated
        if (Vector2.Distance(transform.position, player.transform.position) <= 2f)
        {
            speed = 0;
            squawk();
        }
        // when player leaves crows stopping radius speed is reset and squawk is cancelled
        else
        {
            speed = 1.5f;
            squawking = false;
        }
    }

    //controls crow return mechanics
    private void ReturnStartPoint()
    {
        //when player leaves crows radius, crow will target is starting point and will move towards it
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
        if (transform.position.x > startingPoint.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    //controls sprite direction
    private void Flip()
    {
        if (chase == true)
            {
            if (transform.position.x > player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //controls player detection
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if player collides with crows radius chase = true
        if (collision.CompareTag("Player"))
        {
            chase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when player leaves crows radius chase = false
        if (collision.CompareTag("Player"))
        {
            chase = false;
        }
    }

    //controls crow enemy control mechanics
    private void squawk()
    {
        squawking = true;
        if (squawking == true)
        {
            //atttract nearby enemies.
            //activateCollider();
        }

    }

    private void activateCollider()
    {
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = 30f;
        circleCollider.enabled = true;
    }
}
