using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KittenRetainScale : MonoBehaviour
{
    public void FixScale()
    {
        //transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    public void Detach()
    {
        transform.parent = null;
    }

}
