using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBug : MonoBehaviour {
    public string NextLevelName;

    [SerializeField]
    private float DelayTillNextLevel = 3.0f;

    public void OnTriggerEnter2D(Collider2D WhatEntered)
    {
        if (WhatEntered.gameObject.tag == "Player")
        {
            // Trigger indication to player that they've completed the level



            GameObject.Destroy(gameObject);

        }
    }



    public void OnDestroy()
    {
        if(LevelController.instance!=null)
        LevelController.instance.CheckLevelEnd();
    }
}
