using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class planeAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public GameObject plane;
    public TMP_Text bannerText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        plane = GetComponent<GameObject>(); 
    }

    public void playAnimation(string achievementName)
    {
        bannerText.text = "cleared: "+ achievementName;
        animator.Play("catPlane");
        Debug.Log("plane go burrrrrrr....");
    }

}
