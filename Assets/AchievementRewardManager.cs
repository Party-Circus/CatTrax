using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementRewardManager : MonoBehaviour
{
    public List<AchievementRewardItem> achievementRewards;
    private AchievementManager achievementScript;

    void Start()
    {
        achievementScript = gameObject.GetComponent<AchievementManager>();
        SpawnItems();
    }

    void SpawnItems()
    {
        foreach(AchievementRewardItem itemScript in achievementRewards)
        {
            if(achievementScript.isAchievementUnlocked(itemScript.achievement)){
                itemScript.gameObject.SetActive(true);
            }else{
                itemScript.gameObject.SetActive(false);
            }
        }
    }

    public void SpawnSpecificItem(AchievementID achievement)
    {
        foreach(AchievementRewardItem itemScript in achievementRewards)
        {
            if(itemScript.achievement == achievement)
            {
                itemScript.gameObject.SetActive(true);
            }
        }
    }

}
