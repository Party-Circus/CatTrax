using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CartStats : MonoBehaviour
{
    public AchievementSystem AS;
    public TutorialScript tutorial;
    private bool tutorialMode = false;
    public bool TutorialMode {
        get {
            return tutorialMode;
        }
        set {
            tutorialMode = value;
            if(tutorialMode){
                backgroundMusic.Play();
            }
        }
    }
    private bool hasGameStarted = false;
    public bool HasGameStarted {
        get {
            return hasGameStarted;
        }
        set {
            hasGameStarted = value;
            
            if(hasGameStarted)
            {
                if(tutorialMode)
                {
                    StartGameTutorial();
                }else{
                    StartGame();
                }
                
            }
        }
    } 
    public bool paused = false;
    public Timer timer;
    public int hp;
    [HideInInspector] public int score = 0;
    public float initialTime;
    public HealthBar healthBar;
    public int currentHealth;
    public GameOver gameOverScript;
    public spawningObstacles spawningScript;
    public rotation rotationScript;

    [HideInInspector] public bool isProtected = false;
    

    public GameObject forcefield;

    public float invincFramesTime = 0;
    public bool immune = false;

    public Animator trainAnim;
    public ParticleSystem smokeParticle;

    public AudioSource hitAudioSource;
    public AudioClip hitSound;
    public AudioClip protectSound;

    public AchievementManager AM;

    public int level;

    public int Level
    {
        get { return level; }
        set 
        {
            level = value;
            Debug.Log(level);

            spawningScript.switchTextures(level);
            AS.LevelClearAchievements();
        }
    }
    public AudioSource backgroundMusic;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            if (collision.gameObject.GetComponent<Identifier>())
            {

                if (collision.gameObject.GetComponent<Identifier>().ID == "Cat")
                {
                    AM.UnlockAchievement(AchievementID.TrainRage);
                    Debug.Log("Kitty: " + AM.isAchievementUnlocked(AchievementID.TrainRage));
                }
            }
            if (immune){
                return;
            }
            /*
            if (id == "Cat")
            {
                AM.UnlockAchievement(AchievementID.TrainRage);
                Debug.Log("Kitty" + AM.isAchievementUnlocked(AchievementID.TrainRage)); 
            }
            */
            else if(isProtected){
                isProtected = false;
                forcefield.SetActive(false);
                hitAudioSource.PlayOneShot(protectSound);
            }
            else{
                hp -= 1; 
                currentHealth = hp;//reduce hp by 1
                healthBar.SetHealth(currentHealth);
                Debug.Log("HP: " + hp);

                trainAnim.Play("Base Layer.HitTrain");
                StartCoroutine(Recovery());

                if(collision.gameObject.tag == "HitBox")
                {
                    hitAudioSource.PlayOneShot(hitSound);
                    
                }

            
                if (hp <= 0)
                {
                    Destroy(collision.gameObject.GetComponent<Force>());
                }



                gameOverScript.CheckGameOver();
            }
        }
    }


    private void Start()
    {
        currentHealth = hp;
        Debug.Log("HP: " + hp);
        healthBar.SetMaxHealth(hp);

        if (timer != null)
        {
            timer.timevalue = initialTime;
        }
    }

    IEnumerator Recovery(){

        immune = true;
        trainAnim.SetBool("Immune", true);
        yield return new WaitForSeconds(invincFramesTime);
        immune = false;
        trainAnim.SetBool("Immune", false);
    }



    private void StartGame(){
        
        backgroundMusic.Play();
        smokeParticle.Play();
        spawningScript.StartSpawning();
        trainAnim.SetBool("gameStarted", true);
        timer.StartGame();
    }

    private void StartGameTutorial(){
        smokeParticle.Play();
        trainAnim.SetBool("gameStarted", true);
        timer.StartGame();
    }

    public void StopMidGame(){
        smokeParticle.Pause();
        trainAnim.SetBool("gameStarted", false);
        timer.StopGame();
        rotationScript.PauseRotation();
        spawningScript.gameStopped = true;
    }

    public void ResumeMidGame(){
        smokeParticle.Play();
        trainAnim.SetBool("gameStarted", true);
        timer.StartGame();
        rotationScript.ResumeRotation();
        spawningScript.gameStopped = false;
    }

    
}
