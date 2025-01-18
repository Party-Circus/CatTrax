using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour
{
    public CartStats cartStats;
    public rotation rotation;
    public spawningObstacles spawningScript;
    public List<GameObject> textBoxes;
    private float normalWaitingTime = 6f;

    //Controls to pop in
    public GameObject cat;
    public GameObject whistle;
    public GameObject brake;
    public GameObject control;
    public GameObject furnace;

    //Some triggers to check if actions are being done
    public SlowingDownCheck slowingDownCheck;
    public DangerCheck dangerCheck;
    public MoveCheck moveCheck;
    
    
    void Start()
    {
        cartStats.TutorialMode = true;
        
        Transform textboxHolder = transform.GetChild(0);

        foreach (Transform child in textboxHolder){
            textBoxes.Add(child.gameObject);
        }
        StartCoroutine(InGameTutorial());
    }


    IEnumerator InGameTutorial()
    {
        //Welcome to Cattrax!
        Activate(0);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(0);

        //This is where we'll give you the basics of how to be a Cat Conductor!
        Activate(1);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(1);

        //On this tablet over here, you'll see THREE important things
        Activate(2);
        yield return new WaitForSeconds(1f);

        //Stat labels pop on on screen
        Activate(3);

        yield return new WaitForSeconds(normalWaitingTime - 1f);
        Deactivate(2);

        //Let your time or your health drop to 0 and it's game over!
        Activate(4);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(4);

        //Reach a high score before you go bust!
        Activate(5);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(5);
        Deactivate(3);

        //You got all that?
        //You better not be dozing off!
        Activate(6);
        yield return new WaitForSeconds(normalWaitingTime-3f);
        Deactivate(6);

        //First we need a navigator for our train (33)
        Activate(33);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(33);

        //Grab this black cat and place him on top of the train (34)
        Activate(34);
        cat.SetActive(true);
        yield return new WaitUntil(() => rotation.isCatInCharge);
        Deactivate(34);

        //Great! You can't drive a train without a navigator (35)
        Activate(35);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(35);

        //Let's pull down that whistle to start the game!
        Activate(7);
        whistle.SetActive(true);
        yield return new WaitUntil(() => cartStats.HasGameStarted);
        Deactivate(7);

        //Nice! We're on our way now!
        Activate(9);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(9);

        //Pull that whistle more! You'll go even faster... And your score will go up faster as well!
        Activate(10);
        yield return new WaitForSeconds(normalWaitingTime + 1f);
        Deactivate(10);

        //Whoa! That's fast!
        Activate(11);
        yield return new WaitForSeconds(normalWaitingTime - 1f);
        Deactivate(11);

        //Let's try pumping the breaks a bit
        Activate(12);
        yield return new WaitForSeconds(normalWaitingTime - 2f);
        Deactivate(12);

        //Grab that lever on your left and pull it back
        Activate(13);
        brake.SetActive(true);
        yield return new WaitUntil(() => slowingDownCheck.slowingDown);
        Deactivate(13);

        //Easy does it!
        Activate(14);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(14);
        
        //Your score will be lower, but sometimes slow is the way to go!
        Activate(15);
        spawningScript.SpawnOneEnemy(1);
        yield return new WaitUntil(() => dangerCheck.danger);
        Deactivate(15);

        //Watch out!
        Activate(16);
        cartStats.StopMidGame();
        yield return new WaitForSeconds(normalWaitingTime-3f);
        Deactivate(16);

        //That rock is in the way! Move the switch up or down to avoid it!
        Activate(17);
        control.SetActive(true);
        yield return new WaitUntil(() => moveCheck.moved);
        Deactivate(17);
        cartStats.ResumeMidGame();

        //That was close!
        Activate(18);
        yield return new WaitForSeconds(normalWaitingTime-2f);
        Deactivate(18);

        //If you collide into something, it'll chip away at your Health
        //So don't let that happen!
        Activate(19);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(19);

        yield return new WaitForSeconds(3f);
        spawningScript.SpawnOneCoal(0);
        yield return new WaitUntil(() => dangerCheck.danger);

        //STOP!
        Activate(20);
        cartStats.StopMidGame();
        yield return new WaitForSeconds(normalWaitingTime-3f);
        Deactivate(20);

        //It's another rock, but this one is special!
        Activate(21);
        yield return new WaitForSeconds(normalWaitingTime-1f);
        Deactivate(21);

        //Reach your hand forwards and grab at the rock
        Activate(22);
        yield return new WaitUntil(() => !dangerCheck.danger);
        Deactivate(22);

        //That rock is coal!
        Activate(23);
        cartStats.ResumeMidGame();
        yield return new WaitForSeconds(normalWaitingTime-1f);
        Deactivate(23);

        //If you toss it into this furnace, you'll get some extra time!
        Activate(24);
        furnace.SetActive(true);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(24);

        Activate(25);
        yield return new WaitForSeconds(normalWaitingTime);

        Deactivate(25);

        //Those are all the basics of Cattra-
        Activate(26);
        spawningScript.SpawnBox();
        yield return new WaitUntil(() => dangerCheck.danger);
        Deactivate(26);

        //AAAAH!
        Activate(27);
        cartStats.StopMidGame();
        yield return new WaitForSeconds(normalWaitingTime-2);
        Deactivate(27);

        //This box covers all three tracks! What are we gonna do!?
        Activate(28);
        yield return new WaitUntil(() => !dangerCheck.danger);
        Deactivate(28);

        //You can pick that thing up!?!?
        Activate(29);
        cartStats.ResumeMidGame();
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(29);

        //That's weird, I wonder what else you can...
        Activate(30);
        yield return new WaitForSeconds(normalWaitingTime-1);
        Deactivate(30);

        //Anyways!
        Activate(31);
        yield return new WaitForSeconds(normalWaitingTime-4);
        Deactivate(31);

        //That's all the basics, have fun playing Cattrax!
        Activate(32);
        yield return new WaitForSeconds(normalWaitingTime);
        Deactivate(32);

        SceneManager.LoadScene("Main Menu");

    }

    private void Activate(int x)
    {
        textBoxes[x].SetActive(true);
    }

     private void Deactivate(int x)
    {
        textBoxes[x].SetActive(false);
    }
}