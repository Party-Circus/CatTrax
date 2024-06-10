using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Fly_Away : MonoBehaviour
{
    public CartStats cartScenes;
    public GameObject[] prefabToInstantiate = new GameObject[5];
    private bool canMine = true;
    Vector3 forceAppliedVector = new Vector3(8000.0f, 4000.0f, 2000.0f);
    Vector3 spinVector = new Vector3(500.0f, 500.0f, 500.0f);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe" && cartScenes.Level == 0)
        {
            if (canMine)
            {
            GameObject newPrefab = Instantiate(prefabToInstantiate[0], transform.position, Quaternion.identity);
            newPrefab.GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
            newPrefab.GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
            newPrefab.GetComponent<Rigidbody>().useGravity = true;

            canMine = false;
            StartCoroutine(WaitTimer());
            }
        }
     
        else if (other.tag == "Axe" && cartScenes.Level == 1)
        {
            if (other.tag == "Axe")
            {
                if (canMine)
                {
                    GameObject newPrefab = Instantiate(prefabToInstantiate[1], transform.position, Quaternion.identity);
                    newPrefab.GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().useGravity = true;

                    canMine = false;
                    StartCoroutine(WaitTimer());
                }
            }
        }

        else if (other.tag == "Axe" && cartScenes.Level == 2)
        {
            if (other.tag == "Axe")
            {
                if (canMine)
                {
                    GameObject newPrefab = Instantiate(prefabToInstantiate[2], transform.position, Quaternion.identity);
                    newPrefab.GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().useGravity = true;

                    canMine = false;
                    StartCoroutine(WaitTimer());
                }
            }
        }

        else if (other.tag == "Axe" && cartScenes.Level == 3)
            {
            if (other.tag == "Axe")
            {
                if (canMine)
                {
                    GameObject newPrefab = Instantiate(prefabToInstantiate[3], transform.position, Quaternion.identity);
                    newPrefab.GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().useGravity = true;

                    canMine = false;
                    StartCoroutine(WaitTimer());
                }
            }
        }

        else if (other.tag == "Axe" && cartScenes.Level == 4)
        {
            if (other.tag == "Axe")
            {
                if (canMine)
                {
                    GameObject newPrefab = Instantiate(prefabToInstantiate[4], transform.position, Quaternion.identity);
                    newPrefab.GetComponent<Rigidbody>().AddForce(forceAppliedVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
                    newPrefab.GetComponent<Rigidbody>().useGravity = true;

                    canMine = false;
                    StartCoroutine(WaitTimer());
                }
            }
        } 

    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(3f);
        canMine = true;
    }
}
