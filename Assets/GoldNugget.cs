using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNugget : MonoBehaviour
{
    public AchievementManager AM;
  
    

    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "GoldTrigger")
        {
            AM.UnlockAchievement(AchievementID.GOOOOOOLD);
            Debug.Log("Gold" + AM.isAchievementUnlocked(AchievementID.GOOOOOOLD));
            Debug.Log("Gold Found");
            Destroy(gameObject);

        }
    }
}
