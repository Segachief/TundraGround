using System.Collections;
using System.Linq;
using UnityEngine;
//script written by Jamie Mitchell
public class AxeSwingingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItemData axe;
    public KeyCode Axe_Button;
    Animator myAnimator;
    private bool IsAxeSwinging;
    // Update is called once per frame
    private void Awake()
    {
        myAnimator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        IsAxeSwinging = myAnimator.GetBool("AxeSwing");

        if(Input.GetKeyDown(Axe_Button) && InventoryManager.instance.Inventory.Contains(axe))
        {
            myAnimator.SetTrigger("AxeSwing");
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tree")
        {
            collision.gameObject.GetComponent<InteractableBehaviour>().DestroyTree();
        }
    }



    //two functions to be used by AxeSwingAnimator script
    public void EnableAxeHitbox()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DisableAxeHitbox()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
