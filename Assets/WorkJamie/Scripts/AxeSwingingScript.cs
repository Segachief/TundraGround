using System.Collections;
using System.Linq;
using UnityEngine;

public class AxeSwingingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ItemData axe;
    public KeyCode axebutton;
    Animator myAnimator;
    public GameObject tree;
    // Update is called once per frame
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(axebutton) && InventoryManager.instance.Inventory.Contains(axe))
        {
            myAnimator.SetTrigger("AxeSwing");
            if(InventoryManager.instance.IsTouchingGm == tree)
            {
                tree.GetComponent<InteractableBehaviour>().DestroyTree();
            }

        
            
            
        }

    }


    private IEnumerator WaitForSeconds(float time)
    {

        yield return new WaitForSecondsRealtime(time);
    }
}
