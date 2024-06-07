using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timevalue;
    public TextMeshProUGUI Timertxt;
    public GameOver GameOverScript;

    public bool timerStarted;
    public bool gameStarted = false;

    // Update is called once per frame

    public void StartGame()
    {
        gameStarted = true;
    }

    void Update()
    {
        if(gameStarted)
        {
            if (timevalue > 0)
            {
                timevalue -= Time.deltaTime;
            }
            else
            {
                timevalue = 0;
                if (!GameOverScript.IsGameover)
                {
                    GameOverScript.TriggerGameOverEffects(false);
                }
                    
            }
        }
        DisplayTime(timevalue);
    }
    void DisplayTime(float timetodisplay)
    {
        if (timetodisplay < 0)
        {
            timetodisplay = 0;
            print("Time is UP!");
        }
        else if(timetodisplay > 0)
        {
            timetodisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timetodisplay / 60);
        float seconds = Mathf.FloorToInt(timetodisplay % 60);

        Timertxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
