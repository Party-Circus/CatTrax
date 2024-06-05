using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        plane = GetComponent<GameObject>(); 
    }

    public void playAnimation()
    {
        animator.Play("catPlane");
        Debug.Log("plane go burrrrrrr....");
    }

}
