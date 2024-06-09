using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public CartStats cartStats;
    public AchievementManager AM;


    public void LevelClearAchievements()
    {
        switch (cartStats.level)
        {
            case 1:
                AM.UnlockAchievement(AchievementID.grass);
                Debug.Log("Grass" + AM.isAchievementUnlocked(AchievementID.grass));
                break;
            case 2:
                AM.UnlockAchievement(AchievementID.wildwest);
                Debug.Log("Wildwest" + AM.isAchievementUnlocked(AchievementID.wildwest));
                break;
            case 3:
                AM.UnlockAchievement(AchievementID.volcano);
                Debug.Log("volcano" + AM.isAchievementUnlocked(AchievementID.volcano));
                break;
            case 4:
                AM.UnlockAchievement(AchievementID.tunnel);
                Debug.Log("tunnel" + AM.isAchievementUnlocked(AchievementID.tunnel));
                break;
            case 0:
                AM.UnlockAchievement(AchievementID.gemstone);
                Debug.Log("Gemstone" + AM.isAchievementUnlocked(AchievementID.gemstone));
                break;
        }
    }

    public void RatTraxAchievement()
    {
        AM.UnlockAchievement(AchievementID.rattrax);
        Debug.Log("RatTrax: " + AM.isAchievementUnlocked(AchievementID.rattrax));
        //Check RatTraxChecker.cs
    }
}
