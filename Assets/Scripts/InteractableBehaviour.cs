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


    public void OnTriggerEnter2D()
    {
        InventoryManager.instance.IsTouchingGm = gameObject;
        return;
    }
}

