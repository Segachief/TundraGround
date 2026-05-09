using UnityEngine;

public class WolfDetectionScript : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponentInParent<WolfBehaviour>().PlayerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponentInParent<WolfBehaviour>().PlayerInArea = false;
        }
    }
}
