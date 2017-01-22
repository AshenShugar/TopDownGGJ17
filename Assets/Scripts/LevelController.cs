using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    public string NextLevelName;
    private float DelayTillNextLevel = 3.0f;
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
