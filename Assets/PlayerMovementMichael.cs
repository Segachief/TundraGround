using UnityEngine;

public class PlayerMovementMichael : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() // What happens when the game starts 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() // Whats happens each frame
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirX * 7f, rb.linearVelocity.y);
        

       if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 14f); // gives access to it to add physics 
        }

       if (dirX > 0f)
        {
            anim.SetBool("running", true);
        }
       else if (dirX < 0f)
        {
            anim.SetBool("running", true);
        }
       else
        {
            anim.SetBool("running", false);
        }
    }
} // end of class 
