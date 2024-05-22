using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBmanager : MonoBehaviour
{

    [SerializeField] Canvas SpeedCanvas;
    [SerializeField] Canvas FurnaceCanvas;
    [SerializeField] Canvas LeverCanvas;
    [SerializeField] Canvas PointCanvas;


    //for the speed canvas
    [SerializeField] WhistleSpeed WS;//come from WhistleSpeed script in the speed trigger of the Whistle Gameobject
    [SerializeField] LevelSlow LS;//come from LevelSlow script in the slow trigger of the Break gameobject



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LS.hasSlow && WS.hasTouched)
        {
            SpeedCanvas.enabled = false;
        }
    }
}
