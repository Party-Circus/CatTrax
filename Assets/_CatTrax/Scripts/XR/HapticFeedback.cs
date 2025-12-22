using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField]
    XRBaseController rightController;

    [SerializeField]
    XRBaseController leftController;

    private XRGrabInteractable xRGrabInteractable;

    void Awake()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isObjectGrabbed())
        {
            SendHaptics();
        }
        

    }

    void SendHaptics()
    {
        if (rightController != null)
        {
            rightController.SendHapticImpulse(0.5f, 0.5f);
        }

        if (leftController != null)
        {
            leftController.SendHapticImpulse(0.5f, 0.5f);
        }
    }

    bool isObjectGrabbed()
    {
        return xRGrabInteractable != null && xRGrabInteractable.isSelected;
    }
}




