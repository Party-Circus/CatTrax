using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Fly_Away : MonoBehaviour
{
    private bool pKeyPressedPreviousFrame = false;
    Vector3 forceAppliedVector = new Vector3(8000.0f, 4000.0f, 2000.0f);
    Vector3 spinVector = new Vector3(500.0f, 500.0f, 500.0f);

    void FixedUpdate()
    {
        bool pKeyPressed = Input.GetKey(KeyCode.P);

        if (pKeyPressed && !pKeyPressedPreviousFrame)
        {
            Debug.Log("P pressed");
            GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
            GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
            GetComponent<Rigidbody>().useGravity = true;
        }

        pKeyPressedPreviousFrame = pKeyPressed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Axe")
        {
            GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
            GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
