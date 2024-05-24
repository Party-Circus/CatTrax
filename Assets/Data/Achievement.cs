using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    //Reference for the code
    public string id;

    //Name of the achievement
    public string title;

    //How to get the achievement, only appears after unlocked
    public string description;

    //Hint for the player that will show up to guide them to unlocking
    public string hint;

    //A personal joke or reaction to the achievement
    public string quote;
}
