using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheck : MonoBehaviour
{
    public bool moved = false;
    public MoveCheck otherMove;

    private void OnTriggerStay(Collider other) {

        if(other.CompareTag("Switch"))
        {
            moved = true;
            otherMove.moved = true;

        }    
        
    }
}
