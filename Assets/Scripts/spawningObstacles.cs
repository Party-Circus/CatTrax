using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    private Color colorOne = new Color(0.03f, 0.58f, 0.01f);
    private Color colorTwo = new Color(0.48f, 0.5f, 0.55f);

    public Transform island;

    public rotation rotScript;

    private float baseSpawnTimer = 1f;

    //Use to adjust how frequently things will spawn in general, higher means slower
    public float baseSpawnTimerModifier = 1f;
    public List<Transform> spawnLocations = new List<Transform>();
    public List<GameObject> smallObstacle = new List<GameObject>();
    public List<GameObject> mediumObstacle = new List<GameObject>();
    public List<GameObject> bigObstacle = new List<GameObject>();
    public List<GameObject> coal = new List<GameObject>();

    //Chance for each event to happen out of 100
    // 1 = chance for a single track obstacle to spawn
    // 2 = chance for a double track obstacle to spawn
    // 3 = chance for box
    public List<int> eventsToSpawn = new List<int>();
    private int totalChance = 0;
    
    

    void Start()
    {
        //Base spawn timer is a value that will change with the goal of spawning more frequently when the platform is spinning faster
        //and less frequently when the platform is spinning slower
        baseSpawnTimer = baseSpawnTimerModifier * rotScript.baseRotationSpeed/rotScript.rotationSpeed;

        foreach (Transform child in transform)
        {
            spawnLocations.Add(child.transform);
        }

        for(int i = 0; i < eventsToSpawn.Count; i++){
            totalChance += eventsToSpawn[i];
            eventsToSpawn[i] = totalChance;
           
        }

        StartCoroutine(Spawner(baseSpawnTimer));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        baseSpawnTimer = baseSpawnTimerModifier * rotScript.baseRotationSpeed/rotScript.rotationSpeed;
        
    }

    IEnumerator Spawner(float spawnTimer){

        yield return new WaitForSeconds(spawnTimer);

        //if paused wait until unpaused
        SpawnEnemy();
        

    }

    void SpawnEnemy(){

        float spawnTimer = 0;
        int nextAction = Random.Range(0, totalChance);
        GameObject obstacle;

        if(nextAction < eventsToSpawn[0]){

            int trackSpawn = Random.Range(0, 3);
            int rock = Random.Range(0, smallObstacle.Count);
            obstacle = Instantiate(smallObstacle[rock], spawnLocations[trackSpawn].position, Quaternion.identity, island);

            obstacle.GetComponent<Renderer>().materials[0].color = colorOne;
            obstacle.GetComponent<Renderer>().materials[1].color = colorTwo;


            spawnTimer = Random.Range(baseSpawnTimer * .5f, baseSpawnTimer * 1.5f);
            obstacle.GetComponent<Force>().rotScript = rotScript;

        }

        else if(nextAction < eventsToSpawn[1]){
            int trackSpawn = Random.Range(3, 5);
            int rock = Random.Range(0, mediumObstacle.Count);
            obstacle = Instantiate(mediumObstacle[rock], spawnLocations[trackSpawn].position, Quaternion.identity, island);

            obstacle.GetComponent<Renderer>().materials[0].color = colorOne;
            obstacle.GetComponent<Renderer>().materials[1].color = colorTwo;

            spawnTimer = Random.Range(baseSpawnTimer * 1.5f, baseSpawnTimer * 3f);
            obstacle.GetComponent<Force>().rotScript = rotScript;
        }

        else if(nextAction < eventsToSpawn[2]){
            obstacle = Instantiate(bigObstacle[0], spawnLocations[5].position, Quaternion.identity, island);
            spawnTimer = Random.Range(baseSpawnTimer * 2f, baseSpawnTimer * 4f);
            obstacle.GetComponent<Force>().rotScript = rotScript;
        }

        else if(nextAction < eventsToSpawn[3]){
            int trackSpawn = Random.Range(0, 3);
            Vector3 pos = new Vector3(spawnLocations[trackSpawn].position.x, spawnLocations[trackSpawn].position.y + .7f, spawnLocations[trackSpawn].position.z);
            obstacle = Instantiate(coal[0], pos, Quaternion.identity, island);
            obstacle.GetComponent<Force>().rotScript = rotScript;
            spawnTimer = Random.Range(2f, 4f);
        }


        
        StartCoroutine(Spawner(spawnTimer));
    }

    public void switchTextures(int level)
    {
        switch (level)
        {
            //Grass Level
            case 0:
                colorOne = new Color(0.03f, 0.58f, 0.01f);
                colorTwo = new Color(0.48f, 0.5f, 0.55f);
                break;

            //Sand Level
            case 1:
                colorOne = new Color(0.58f, 0.37f, 0.26f);
                colorTwo = new Color(0.69f, 0.44f, 0.32f);
                break;

            //Volcano
            case 2:
                colorOne = new Color(0.99f, 0.26f, 0.24f);
                colorTwo = new Color(0.27f, 0.24f, 0.25f);
                break;

            //Tunnel
            case 3:
                colorOne = new Color(0.61f, 0.56f, 0.51f);
                colorTwo = new Color(0.61f, 0.56f, 0.51f);
                break;

            //Gemstone
            case 4:
                colorOne = new Color(0.29f, 0.92f, 0.86f);
                colorTwo = new Color(0.29f, 0.92f, 0.86f);
                break;
        }
    }
}
