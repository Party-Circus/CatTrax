using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelVisualizer : MonoBehaviour
{
    [SerializeField] Transform activeLevel;
    [SerializeField] Transform[] levels;
    
   
   


    [ContextMenu("ShowGrassLevel()")]
    private void ShowGrassLevel(){
        ShowLevel(levels[0]);
    }

    [ContextMenu("ShowWildWestLevel()")]
    private void ShowWildWestLevel(){
        ShowLevel(levels[1]);
    }

    [ContextMenu("ShowVolcanoLevel()")]
    private void ShowVolcanoLevel(){
        ShowLevel(levels[2]);
    }

    [ContextMenu("ShowTunnelLevel()")]
    private void ShowTunnelLevel(){
        ShowLevel(levels[3]);
    }

    [ContextMenu("ShowGemLevel()")]
    private void ShowGemLevel(){
        ShowLevel(levels[4]);
    }



    private void ShowLevel(Transform levelToShow)
    {

        foreach (Transform piece in activeLevel){
            piece.GetComponent<MeshRenderer>().enabled = false;
            Transform props = piece.GetChild(0);
            props.gameObject.SetActive(false);
        }
        


        foreach (Transform piece in levelToShow){
            piece.GetComponent<MeshRenderer>().enabled = true;
            Transform props = piece.GetChild(0);
            props.gameObject.SetActive(true);
        }
        activeLevel = levelToShow;

    }

    

}
