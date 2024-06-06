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
        GrabInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        if (selectedObject.CompareTag("MountGrab"))
        {
            selectedObject.GetComponent<XRGrabInteractable>().retainTransformParent = false;
        }
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