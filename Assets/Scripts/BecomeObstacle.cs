using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BecomeObstacle : MonoBehaviour
{
    public GameObject parentObject;
    

    private void OnCollisionEnter(Collision collision)
    {
        GameObject selectedObject = collision.transform.gameObject;
        if (!selectedObject.CompareTag("Player")) 
        { 
            selectedObject.transform.SetParent(parentObject.transform, true);
            selectedObject.gameObject.tag = "HitBox";
            
            selectedObject.AddComponent<Force>();
        }

        selectedObject.GetComponent<XRGrabInteractable>().retainTransformParent = false; //Prevent Object from returning to parent


    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject selectedObject = collision.transform.gameObject;
        if (selectedObject.transform.parent == parentObject.transform)
        {
            selectedObject.transform.SetParent(null);
        }

        if (!selectedObject.CompareTag("Player"))
        {
            selectedObject.gameObject.tag = "MountGrab";
        }

        Destroy(selectedObject.GetComponent<Force>());
    }
}
