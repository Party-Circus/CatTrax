using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public CartStats cartStats;
    void Start()
    {
        cartStats.TutorialMode = true;
    }

    // Update is called once per frame
    public void StartGameTutorial()
    {

    }
}