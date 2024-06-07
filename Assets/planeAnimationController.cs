using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class planeAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public GameObject plane;
    public TMP_Text bannerText;

    //variables for state controller
    string currentState;
    const string idle = "idle";
    const string flying ="catPlane";

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

    private void chageAnimationState(string newState)
    {
        if(newState == currentState)
        {
            return;
        }

        animator.Play(newState);
        currentState = newState;
    }

    //checks to see if the given animation is still playing
    bool isAnimationPlaying(Animator animator, string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
            return false;
    }

}
