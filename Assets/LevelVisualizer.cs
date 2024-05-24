using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelVisualizer : MonoBehaviour
{

    private Transform child;
    // Start is called before the first frame update
    private void ShowLevel()
    {
        GetComponent<MeshRenderer>().enabled = true;
        child = transform.GetChild(0);
        child.gameObject.SetActive(true);
    }

    private void HideLevel(){
        GetComponent<MeshRenderer>().enabled = false;
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

}
