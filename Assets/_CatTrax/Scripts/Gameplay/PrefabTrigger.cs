using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    public string[] tags;

    public Light lights;
    
    float currentExposure = 2;
    
    private bool changeLevel = false;
    private int level = 0;
    private int prevLevel = -1;


    public LevelSettings firstLevel;



    public Transform child;
    
    public AchievementManager achievementManager;

    void Start(){
        //Debug.Log("Happened");
        //RenderSettings.skybox.SetFloat("_Exposure", 1f);
        StartCoroutine(AdjustTheLights(firstLevel.brightness));
        StartCoroutine(AdjustTheExposure(firstLevel.skyboxExposure));
        StartCoroutine(AdjustTheWarmth(firstLevel.warmness));

    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            level++;
            changeLevel = true;
            Debug.Log(changeLevel);
        }*/

    }

    public int changeTerrian()
    {
        level++;
        prevLevel = level - 1;
       
       //Hardcoded, if first level

        if(level >= tags.Length){
            level = 0;
        }
        changeLevel = true;
   
        return level;
    }

    void OnTriggerEnter(Collider other)
    {
        bool lightChanged = false;
        if (changeLevel){

            if (other.CompareTag(tags[prevLevel]))
            {
                other.GetComponent<MeshRenderer>().enabled = false;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(false);
            }

            if (other.CompareTag(tags[level]))
            {
                if(!lightChanged){
                   LevelSettings levelSet = other.transform.parent.GetComponent<LevelSettings>();
                   StartCoroutine(AdjustTheLights(levelSet.brightness));
                   StartCoroutine(AdjustTheExposure(levelSet.skyboxExposure));
                   StartCoroutine(AdjustTheWarmth(levelSet.warmness));
                   
                   
                   lightChanged = true;
                }


                other.GetComponent<MeshRenderer>().enabled = true;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(true);
            }
        }
        
    }

    IEnumerator AdjustTheLights(float brightness)
    {
        yield return new WaitForSeconds(2);

        while (lights.intensity != brightness)
        {
            lights.intensity = brightness;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator AdjustTheExposure(float targetExposure)
    {
        yield return new WaitForSeconds(2);

        while (currentExposure != targetExposure)
        {
            currentExposure = targetExposure;
            RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            DynamicGI.UpdateEnvironment();
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator AdjustTheWarmth(float warmness)
    {
        yield return new WaitForSeconds(2);

        while (lights.colorTemperature != warmness)
        {
            lights.colorTemperature = warmness;
    
            yield return new WaitForEndOfFrame();
        }
    }


  //lights.temperature != warmness && lights.intensity != brightness && 
}
