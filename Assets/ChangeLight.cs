using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        
        //Light light = other.GetComponent<Light>();
        if (other.TryGetComponent(out Light light))
        {
            Debug.Log(light);

            light.enabled = !light.enabled;
        }
    }
}
