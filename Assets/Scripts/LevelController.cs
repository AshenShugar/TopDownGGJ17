using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {
    public string NextLevelName;
    private float DelayTillNextLevel = 3.0f;
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public int maxEnemies = 5;
    public int maxDelayBeforeSpawnEnemy=UGameLogic.lengthOfSecond*10;
    public int delayBeforeEnemySpawn = 0;
    public GameObject instanciateEnemy;
    public List<Vector3> spawnEnemyPositions = new List<Vector3>();
    public System.Random spawnRandom = new System.Random();
    public static LevelController instance;
    // Use this for initialization
    void Start () {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        delayBeforeEnemySpawn--;
        if(delayBeforeEnemySpawn<1)
        {
            delayBeforeEnemySpawn = maxDelayBeforeSpawnEnemy;
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i] == null)
                {
                    spawnedEnemies.RemoveAt(i);
                    i--;
                }
            }

            if (instanciateEnemy != null && spawnEnemyPositions.Count > 0 && spawnedEnemies.Count < maxEnemies)
            {
                GameObject enemy = GameObject.Instantiate(instanciateEnemy);
                Enemy1 es = enemy.GetComponent<Enemy1>();
                es.wakeUp();
                spawnedEnemies.Add(enemy);
                enemy.transform.position = spawnEnemyPositions[spawnRandom.Next(0, spawnEnemyPositions.Count)];
            }
        }
	}

    public void CheckLevelEnd()
    {
        GoalBug[] bugs = GameObject.FindObjectsOfType<GoalBug>();
        if (bugs.Length == 0)
        {



            Invoke("LoadNext", DelayTillNextLevel);
        }
    }

    public void LoadNext()
    {
        instance = null;
        SceneManager.LoadScene(NextLevelName);
    }

}
