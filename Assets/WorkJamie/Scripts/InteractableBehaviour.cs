using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//-Jamie's amazing script
public class InteractableBehaviour : MonoBehaviour
{
    private GameObject player;
    public GameObject wood;
    private void Start()
    {
        player = GameObject.Find("Player");

    }
   
    //IsTouchingGm is a reference to the gameobject that the player is currently collding with , any interactions are done in the inventorymanager
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            InventoryManager.instance.IsTouchingGm = gameObject;
                return;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            InventoryManager.instance.IsTouchingGm = null;
            return;
        }
    }



    public void DestroyTree()
    {
        InventoryManager.instance.IsTouchingGm = null;
        if (gameObject.name == "tree")
        {
            Instantiate(wood,gameObject.transform.position,Quaternion.identity);
        }
        
        Destroy(this.gameObject);
    }
}


