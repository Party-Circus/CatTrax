using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineSelection : MonoBehaviour
{ 
    Outline outline;
    public XRDirectInteractor directInteractorLeft;
    public XRDirectInteractor directInteractorRight;


    private void OnEnable()
    {
        directInteractorLeft.hoverEntered.AddListener(OnHoverEnter);
        directInteractorLeft.hoverExited.AddListener(OnHoverExit);

        directInteractorRight.hoverEntered.AddListener(OnHoverEnter);
        directInteractorRight.hoverExited.AddListener(OnHoverExit);
    }

    private void OnDisable()
    {
        directInteractorLeft.hoverEntered.RemoveListener(OnHoverEnter);
        directInteractorLeft.hoverExited.RemoveListener(OnHoverExit);

        directInteractorRight.hoverEntered.RemoveListener(OnHoverEnter);
        directInteractorRight.hoverExited.RemoveListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        if (!selectedObject.GetComponent<Outline>())
        {
            outline = selectedObject.AddComponent<Outline>();
        }
        else { outline = selectedObject.GetComponent<Outline>(); }
        
        outline.enabled = true;
        
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {

        GameObject selectedObject = args.interactableObject.transform.gameObject;
        if (!selectedObject.GetComponent<Outline>())
        {
            outline = selectedObject.AddComponent<Outline>();
        }
        else { outline = selectedObject.GetComponent<Outline>(); }

        outline.enabled = false;
    }
}
