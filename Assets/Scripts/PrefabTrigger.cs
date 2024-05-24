using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    public string[] tags;

    public Light lights;
    
    float currentExposure = 1;
    
    private bool changeLevel = false;
    private int level = 0;
    private int prevLevel = -1;
    

    public Transform child;

    public AchievementManager achievementManager;



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
                   //evelSettings levelSet = other.transform.parent.GetComponent<LevelSettings>();
                   //StartCoroutine(AdjustTheLights(levelSet.skyboxExposure));
                   //RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
                   
                   lightChanged = true;
                }


                other.GetComponent<MeshRenderer>().enabled = true;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(true);
            }
        }
        
    }

    IEnumerator AdjustTheLights(float targetExposure)
    {
        while (currentExposure != targetExposure)
        {
            Debug.Log("adjusting light");
            currentExposure = Mathf.Lerp(currentExposure, targetExposure, 1f);
            RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            yield return new WaitForEndOfFrame();
        }
    }

  //lights.temperature != warmness && lights.intensity != brightness && 
}
