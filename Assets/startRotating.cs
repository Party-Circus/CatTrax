using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRotating : MonoBehaviour
{
    public rotation rot;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rot.SpeedUpRotation();
        animator.Play("TrainRumbling");
        //animator.SetBool("gameStarted", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
