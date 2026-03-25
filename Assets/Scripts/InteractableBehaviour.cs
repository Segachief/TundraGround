using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//-Jamie's amazing script
public class InteractableBehaviour : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");

    }


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
}


