using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementDatabase database;
    public AchievementID achievementToShow;

    public TMP_Text WantedAchievementName;
    public TMP_Text WantedAchievementHint;

    //An object which contains the achievement Data
    public GameObject achievementItemPrefab;
    public Transform content;

    [SerializeField][HideInInspector]
    private List<AchievementItemController> achievementItems;

    private AchievementRewardManager rewardManager;



    void Start()
    {
        rewardManager = gameObject.GetComponent<AchievementRewardManager>();
        LoadAchievementsTable();
        ShowNextAchievement();
    }


    [ContextMenu("LoadAchievementsTable()")]
    private void LoadAchievementsTable()
    {
        foreach (AchievementItemController item in achievementItems)
        {
            DestroyImmediate(item.gameObject);
        }
        achievementItems.Clear();

        foreach (Achievement achievement in database.achievements)
        {
            GameObject obj = Instantiate(achievementItemPrefab, content);
            AchievementItemController item = obj.GetComponent<AchievementItemController>();
            bool unlocked = PlayerPrefs.GetInt(achievement.id, 0) == 1;
            item.unlocked = unlocked;
            item.achievement = achievement;
            item.RefreshView();
            achievementItems.Add(item);
            
        }
    }

    private void ShowNextAchievement()
    {
        foreach (AchievementItemController item in achievementItems)
        {
            if(!item.unlocked){
                WantedAchievementName.text = item.achievement.title;
                WantedAchievementHint.text = item.achievement.hint;
                return;
            }
        }
    }

    public void UnlockAchievement(AchievementID achievement) 
    {
        AchievementItemController item = achievementItems[(int)achievement];
        //If achievment is already unlocked don't unlock it again
        if (PlayerPrefs.GetInt(item.achievement.id, 0) == 1)
            return;

        //ShowNotification();
        PlayerPrefs.SetInt(item.achievement.id, 1);
        item.unlocked = true;
        item.RefreshView();
        ShowNextAchievement();
        rewardManager.SpawnSpecificItem(achievement);
    }

    [ContextMenu(" ClearAchievementsInPlayerPrefs()")]
    private void ClearAchievementsInPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public bool isAchievementUnlocked(AchievementID achievement)
    {
        
        AchievementItemController item = achievementItems[(int)achievement];
        if (PlayerPrefs.GetInt(item.achievement.id, 0) == 1)
        {
            return true;
        }else{
            return false;
        }
    }
}
