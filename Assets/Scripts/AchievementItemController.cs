using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AchievementItemController : MonoBehaviour
{

    
    [SerializeField] Image achievementIcon;

    [SerializeField] TMP_Text titleLabel;
    [SerializeField] TMP_Text descriptionLabel;


    public bool unlocked;
    public Achievement achievement;

    public void RefreshView()
    {
        titleLabel.text = achievement.title;
        descriptionLabel.text = achievement.description;

        if (unlocked)
        {
            achievementIcon.color = Color.white;
            titleLabel.enabled = true;
        }
        else
        {
            achievementIcon.color = Color.black;
            titleLabel.enabled = false;
        }
        /*unlockedIcon.enabled = unlocked;
        lockedIcon.enabled = !unlocked;*/
    }

    private void OnValidate()
    {
        RefreshView();
    }
}
