using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingDownCheck : MonoBehaviour
{
    public bool slowingDown = false;

    private void OnTriggerStay(Collider other) {
        slowingDown = true;
    }
}
