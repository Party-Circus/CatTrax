using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KittenRetainScale : MonoBehaviour
{
    //New Name for Script: Make into Tag Cat - Chris

    private void OnEnable()
    {
        var GrabInteractable = GetComponent<XRGrabInteractable>();
        GrabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        selectedObject.gameObject.tag = "Cat";
    }

    public void lol()
    {
        gameObject.tag = "Cat";
    }

}
