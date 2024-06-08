using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNugget : MonoBehaviour
{
    public AchievementManager AM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "GoldTrigger")
        {
            AM.UnlockAchievement(AchievementID.GOOOOOOLD);
            Debug.Log("Gold Found");

        }
    }
}
