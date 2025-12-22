using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RatTraxChecker : MonoBehaviour
{
    public AchievementSystem AS;

    private void Start()
    {
        Debug.Log("RatTraxChecker Works");
    }

    private void OnEnable()
   {
       var socketInteractor = GetComponent<SocketWithTagCheck>();
       socketInteractor.selectEntered.AddListener(OnSelectEntered); 
   }

   private void OnDisable()
   {
       var socketInteractor = GetComponent<SocketWithTagCheck>();
       socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
   }

   private void OnSelectEntered(SelectEnterEventArgs args)
   {

        GameObject selectedObject = args.interactableObject.transform.gameObject;
        if(selectedObject.GetComponent<Identifier>())
        {
            if (selectedObject.GetComponent<Identifier>().ID == "Rat")
            {
                AS.RatTraxAchievement();
            }
        }

   }
}
