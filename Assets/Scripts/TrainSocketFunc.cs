using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrainSocketFunc : MonoBehaviour
{
    public GameObject parentObject; // The parent object to which the socketed object will be attached
    //public GameObject ratObjectTwo;
    //public GameObject ratObjectThree;
    public CartStats cart;
    public rotation rotScript;
    

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

        rotScript.isCatInCharge = true;
        if (cart.HasGameStarted)
        {
            cart.YesCat();
        }
       
    }


    private void OnSelectExited(SelectExitEventArgs args) 
    {
        //Debug.Log("No Cat Detected");
        cart.NoCat();
        rotScript.isCatInCharge = false;



    }
}
