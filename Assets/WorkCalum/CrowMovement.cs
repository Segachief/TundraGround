using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{//Calum Yule
    
    public float speed;
    public bool chase = false;
    public bool squawking = false;
    public Transform startingPoint;

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

    private void Chase()
    {
        transform.position=Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) <= 2f)
        {
            speed = 0;
            squawk();
        }
        else
        {
            speed = 1;
            squawking = false;
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
        if (transform.position.x > startingPoint.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chase = false;
        }
    }

    private void squawk()
    {
        squawking = true;
        if (squawking == true)
        {
            //atttract nearby enemies.
        }

    }
}
