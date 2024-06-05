using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Move : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;
    public int maxLeftPositions = -1; // Set the maximum left positions
    public int maxRightPositions = 1; // Set the maximum right positions
    private int currentXPosition = 0; // Tracks the current position
    public AudioSource switchtrack;
    public AudioClip switchsound;

    Vector3 centerPos;
    Vector3 leftPos;
    Vector3 rightPos;

    //public Animator trainAnim;

    //public rotation rotScript;

    public bool canInput = true;
    public GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        centerPos = transform.position;
        leftPos = centerPos;
        rightPos = centerPos;

        leftPos.x -= 4;
        rightPos.x += 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //trainAnim.speed = rotScript.rotationSpeed; 

        // Move Left
        if (Input.GetKey(KeyCode.A) && canInput)
        {
            StartCoroutine(CartSwitchLeft());

        }

        //Move Middle
        if (Input.GetKey(KeyCode.S) && canInput)
        {
            StartCoroutine(CartSwitchMiddle());

        }

        // Move Right
        if (Input.GetKey(KeyCode.D) && canInput)
        {
            StartCoroutine(CartSwitchRight());
        }
        //Look into making the positions into an array and switch positions

    }

    public IEnumerator CartSwitchLeft() 
    {

        //canInput = false;
        if(!gameOver.IsGameover)
        {
            transform.SetPositionAndRotation(leftPos, Quaternion.identity); // Move left by 4 units

            switchtrack.PlayOneShot(switchsound);

            yield return new WaitForSeconds(.1f);
        }
        //canInput = true;

    }

    public IEnumerator CartSwitchMiddle()
    {
        //canInput = false;
        if(!gameOver.IsGameover)
        {
            transform.SetPositionAndRotation(centerPos, Quaternion.identity); 

            switchtrack.PlayOneShot(switchsound);

            yield return new WaitForSeconds(.1f);
        }
        //canInput = true;
    }

    public IEnumerator CartSwitchRight()
    {

        //canInput = false;
        if(!gameOver.IsGameover)
        {
            transform.SetPositionAndRotation(rightPos, Quaternion.identity); // Move left by 4 units

            switchtrack.PlayOneShot(switchsound);

            yield return new WaitForSeconds(.1f);
        }
        //canInput = true;

    }


}
