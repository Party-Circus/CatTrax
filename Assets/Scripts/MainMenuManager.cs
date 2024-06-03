using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainMenuPanel;
    public GameObject achievementPanel;

    public void quitButton()
    {
        Debug.Log("Bro is leaving the game!! ");
       
        Application.Quit();//Stop the normies (actual players' game)
    }

    public void goToAchievement()
    {
        mainMenuPanel.SetActive(false);
        achievementPanel.SetActive(true);
    }

    public void goToMainMenu()
    {
        if(mainMenuPanel == null)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else {
            achievementPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        
    }

    public void play()
    {
        SceneManager.LoadScene("Main Game");
    }
}
