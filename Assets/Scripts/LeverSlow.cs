using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.ParticleSystemModule;

public class LevelSlow : MonoBehaviour
{
    public CartStats cartStats;
    public rotation rotScript;
    //public Rotation rotScript; // Assuming Rotation is the correct class 

    public ParticleSystem brakeSparks;
    public ParticleSystem trainSparks;
    public AudioSource audioSource;

    //boolean added for tutorial, should not break anything :)
    public bool hasSlow = false;

    void Start()
    {
        
    }

   
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (cartStats.HasGameStarted)
        {
            Debug.Log("Lever Script");
            rotScript.SlowDownRotation();
    
            hasSlow = true;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            trainSparks.Play();
            //brakeSparks.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        trainSparks.Stop();
        //brakeSparks.Stop();
        audioSource.Stop();
        
    }



}


