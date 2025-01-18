using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCheck : MonoBehaviour
{
    public bool danger = false;
    public bool coalDanger = false;

    private void OnTriggerEnter(Collider other) {
        danger = true;
    }

    private void OnTriggerExit(Collider other) {
        danger = false;
    }
}
