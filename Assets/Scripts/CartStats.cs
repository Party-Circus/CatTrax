using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CartStats : MonoBehaviour
{
    public AchievementManager AM;

    private bool hasGameStarted = false;
    public bool HasGameStarted {
        get {
            return hasGameStarted;
        }
        set {
            hasGameStarted = value;
            
            if(hasGameStarted)
            {
                StartGame();
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

    [HideInInspector] public bool isProtected = false;
    

    public GameObject forcefield;

    public float invincFramesTime = 0;
    public bool immune = false;

    public Animator trainAnim;
    public ParticleSystem smokeParticle;

    public AudioSource hitAudioSource;
    public AudioClip hitSound;
    public AudioClip protectSound;

    public int level;
    public int Level
    {
        get { return level; }
        set 
        {
            level = value;
            Debug.Log(level);

            spawningScript.switchTextures(level);
            LevelClearAchievements();
        }
    }
    public AudioSource backgroundMusic;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            if(immune){
                return;
            }
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
    }

    public void LevelClearAchievements()
    {
        switch (level)
        {
            case 1:
                AM.UnlockAchievement(AchievementID.grass);
                Debug.Log("Grass" + AM.isAchievementUnlocked(AchievementID.grass));
                break;
            case 2:
                AM.UnlockAchievement(AchievementID.wildwest);
                Debug.Log("Wildwest"+AM.isAchievementUnlocked(AchievementID.wildwest));
                break;
            case 3:
                AM.UnlockAchievement(AchievementID.volcano);
                Debug.Log("volcano" + AM.isAchievementUnlocked(AchievementID.volcano));
                break;
            case 4:
                AM.UnlockAchievement(AchievementID.tunnel);
                Debug.Log("tunnel" + AM.isAchievementUnlocked(AchievementID.tunnel));
                break;
            case 0:
                AM.UnlockAchievement(AchievementID.gemstone);
                Debug.Log("Gemstone" + AM.isAchievementUnlocked(AchievementID.gemstone));
                break;
        }
    }

}
