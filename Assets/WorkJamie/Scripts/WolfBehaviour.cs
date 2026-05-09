using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum States
    {
        Roaming,
        Hunt,
        Attack,
        Trapped,
    }
    States CurrentState;
    GameObject hitboxgm;
    public GameObject player;
    public bool PlayerInArea = false;
    bool IsAttacking = false;
    bool IsRoaming = false;
    Vector3 saved_pos;
    Vector3 random_offset;

    void Start()
    {
        
        hitboxgm = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        Roam();
        if (PlayerInArea)
        {
            StartCoroutine(Attack());
        }
    }

    
    public IEnumerator Attack()
    {
        IsAttacking = true;

        hitboxgm.SetActive(true);
        yield return new WaitForSeconds(1f);
        hitboxgm.SetActive(false);
        IsAttacking = false;
        yield return new WaitForSeconds(1f);
    }

    public void Roam()
    {
        if (!IsRoaming)
        {
            saved_pos = transform.position;
            random_offset = new Vector3(Random.Range(-2, 2f), 0f);
            // Flip depending on direction
            if (random_offset.x < 0)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);

            IsRoaming = true;
        }
        //roaming cod
        transform.position = Vector3.MoveTowards(transform.position,saved_pos + random_offset,1f * Time.deltaTime);
      


        if (transform.position == saved_pos + random_offset)
        {
            IsRoaming = false;
        }
    }

    bool IsThereAFloor()
    {
        Vector3 origin = new Vector3(transform.position.x + 1, transform.position.y, 1);
        bool hit = Physics2D.Raycast(origin, Vector3.down, 0.2f,LayerMask.GetMask("Ground"));
        return hit;
    }
}
