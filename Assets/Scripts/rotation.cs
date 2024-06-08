using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameOver gameOver;
    public CartStats cartStats;


    [HideInInspector] public float baseRotationSpeed = .5f;
    // Initial rotation speed
    public float rotationSpeed = 0f;
    private float rotationSaver;

    // speed increase rate per second
    private float speedIncreaseRate = 0.2f;

    //rate of slowing down
    private float slowDownRate = 0.4f;

    // Minimum and maximum rotation speed
    private float minRotationSpeed = 0.1f;
    private float maxRotationSpeed = 1.9f;

    public AchievementManager achievementManager;

    //public spawningObstacles spawnScript;


    

    // Start is called before the first frame update
    void Start()
    {
        //achievementManager.UnlockAchievement(AchievementID.goolik);
        //Debug.Log(achievementManager.isAchievementUnlocked(AchievementID.goolik));
    }

    // Update is called once per frame
    private void FixedUpdate() {
        
     

        
        if (Input.GetKey(KeyCode.Z))
        {
            SpeedUpRotation();
        }

        if (Input.GetKey(KeyCode.X))
        {
            SlowDownRotation();
        }


        transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
        
    }

    

    // Slowly increase in speed at a slow rate over time in int
    //be able to slow down a set amount but not to zero
    //dummy
    public void SpeedUpRotation()
    {
        if(!cartStats.HasGameStarted){
            cartStats.HasGameStarted = true;
            
        }

        if (gameOver.IsGameover)
        {
            return;
        }

        // Increase rotation speed
        rotationSpeed += speedIncreaseRate * Time.deltaTime;

        // maximum speed
        rotationSpeed = Mathf.Clamp(rotationSpeed, minRotationSpeed, maxRotationSpeed);
    }

    public void SlowDownRotation()
    {
        if (gameOver.IsGameover)
        {
            return;
        }

        rotationSpeed -= slowDownRate * Time.deltaTime;

        rotationSpeed = Mathf.Clamp(rotationSpeed, minRotationSpeed, maxRotationSpeed);
    }

    public void SlowDownRotationToZero()
    {
        StartCoroutine(SlowMotion());
    }

    private IEnumerator SlowMotion()
    {
        
        while (rotationSpeed > 0)
        {
            rotationSpeed -= 1f * Time.deltaTime;
            yield return null;
            rotationSpeed = Mathf.Max(0, rotationSpeed);
        }
    }

    public void PauseRotation()
    {
        rotationSaver = rotationSpeed;
        rotationSpeed = 0;
    }

    public void ResumeRotation()
    {
        rotationSpeed = rotationSaver;
    }


    //capture the speed, then slow it down, then after slow down timer has elapsed, rapidly build up back to original speed
}
