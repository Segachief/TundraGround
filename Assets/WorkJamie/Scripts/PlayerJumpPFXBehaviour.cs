using UnityEngine;

public class PlayerJumpPFXBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool ToBeDestroyed = false;
    void Awake()
    {
        
        PlayerJumpPFXBehaviour[] tests = FindObjectsOfType(typeof(PlayerJumpPFXBehaviour)) as PlayerJumpPFXBehaviour[];
        if (tests.Length > 2)
        {
            ToBeDestroyed = true;
        }

    }
    private void Start()
    {
        if (ToBeDestroyed)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}

