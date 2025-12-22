using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTutorialCat : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            Vector3 position = new Vector3(48, -1, 71);
            Quaternion rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            other.transform.SetPositionAndRotation(position, rotation);

            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //Achievement if you throw it out of bounds
        }
    }
}
