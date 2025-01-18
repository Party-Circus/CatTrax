using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleSpeed : MonoBehaviour
{

    public rotation rotScript;
    // public AudioSource audioSource;
    //public AudioClip chooChooSound;

    //boolean added for tutorial, should not break anything :)
    public bool hasTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (rotScript.isCatInCharge == false)
        {
            return;
        }

        //Test if code works, its suppose to prevent whistle from speeding up if the game is in gameOver 
        rotScript.SpeedUpRotation();

        hasTouched = true;//moves the tutorial forward
    }

    public bool getHasTouched()
    {
        return hasTouched; 
    }

    /*void OnTriggerEnter(Collider other) {
        audioSource.PlayOneShot(chooChooSound);
    }*/
}

