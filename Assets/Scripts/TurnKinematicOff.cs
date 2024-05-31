using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnKinematicOff : MonoBehaviour
{
    private void OnEnable()
    {
        var GrabInteractable = GetComponent<XRDirectInteractor>();
        GrabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        if (selectedObject.CompareTag("MountGrab"))
        { 
            Rigidbody rigidBody = selectedObject.GetComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
        }
    }
}