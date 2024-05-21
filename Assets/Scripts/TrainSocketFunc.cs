using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrainSocketFunc : MonoBehaviour
{
    public GameObject parentObject; // The parent object to which the socketed object will be attached

    private void OnEnable()
    {
        var socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnSelectEntered); 
        socketInteractor.selectExited.AddListener(OnSelectExited); 
    }

    private void OnDisable()
    {
        var socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        socketInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
 
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        selectedObject.transform.localScale = new Vector3(0.547241449f, 0.547241449f, 0.911781847f);
        



        selectedObject.transform.SetParent(parentObject.transform, false);
       

    }

    private void OnSelectExited(SelectExitEventArgs args)
    {

        GameObject selectedObject = args.interactableObject.transform.gameObject;
        selectedObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        if (selectedObject.transform.parent == parentObject.transform)
        {
            selectedObject.transform.SetParent(null);
        }
    }//selectedObject.transform.localScale = new Vector3(0.547241449f, 0.547241449f, 0.911781847f);
}
