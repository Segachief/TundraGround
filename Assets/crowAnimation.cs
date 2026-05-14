using UnityEngine;

public class crowAnimation : MonoBehaviour
{

    private Animator _anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimatorMove(float move)
    {
        //_anim.SetFloat("Move", Mathf.Abs(move));
    }

}
