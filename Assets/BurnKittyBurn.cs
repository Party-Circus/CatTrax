using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnKittyBurn : MonoBehaviour
{
    public AchievementManager AM;
    //public Coal coal;
    /*public Furnace furnace;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cat")
        {
            AM.UnlockAchievement(AchievementID.catintofurnance);
            Debug.Log("Cat has been Sacrificed");
            //Destroy(gameObject);
            //coal.OnBurningComplete();
            furnace.StartBurning();

        }
    }
    */

    public Animator kittyAnimator; // Reference to the burning animation
    public ParticleSystem smokeParticles; // Reference to the smoke particle system
    public ParticleSystem fireParticles; // Reference to the fire particle system

    private bool isBurning = false; // Flag to track if the kitty is burning

    private void OnTriggerEnter(Collider other)
    {
        if (!isBurning)
        {
            Furnace furnace = other.GetComponent<Furnace>();
            if (furnace != null)
            {
                furnace.SetKittyReference(this); // Pass a reference to the kitty object
                furnace.StartBurning();
                Debug.Log("Kitty added to furnace.");

                kittyAnimator.SetBool("Burning", true);


                // Activate the particle systems for fire and smoke
                if (smokeParticles != null)
                {
                    smokeParticles.Play();
                }
                if (fireParticles != null)
                {
                    fireParticles.Play();
                }
            }
        }
    }

    // Called when the furnace finishes burning
    public void OnBurningComplete()
    {
        // Stop the particle systems for fire and smoke
        if (smokeParticles != null)
        {
            smokeParticles.Stop();
        }
        if (fireParticles != null)
        {
            fireParticles.Stop();
        }

        AM.UnlockAchievement(AchievementID.catintofurnance);
        Debug.Log("Kitty" + AM.isAchievementUnlocked(AchievementID.catintofurnance));

        // Destroy the kitty object
        Destroy(gameObject);
    }
}
