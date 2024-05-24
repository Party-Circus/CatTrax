using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detach : MonoBehaviour
{
    public void DetachFromParent()
    {
        transform.parent = null;
    }

}
