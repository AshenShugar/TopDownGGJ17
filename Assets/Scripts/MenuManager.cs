﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	private GameManager GM;

	[SerializeField]
	private GameObject optionPanel;

	[SerializeField]
	private GameObject MainMenuUIParent;

	public void ChangeNumberOfPlayers( int deltaNOP)
	{
		GM.NumberOfPlayers += deltaNOP;

		if (GM.NumberOfPlayers > GM.MaxNumberOfPlayers)
			GM.NumberOfPlayers = 2;

		if (GM.NumberOfPlayers == 1	)
			GM.NumberOfPlayers = GM.MaxNumberOfPlayers;

	}

	public void ToggleOptionPanel()
	{
		optionPanel.SetActive (!optionPanel.activeSelf);
	}

	// Use this for initialization
	void Start () {
		GM = FindObjectOfType<GameManager> ();

		if (GM == null) {
			Debug.LogWarning("GameManager script not present, creating now");
			GameObject tmpObj = new GameObject();
			tmpObj.name = "GameManagerObj";
			GM = tmpObj.gameObject.AddComponent<GameManager> ();
			if (GM == null) {
				Debug.LogWarning ("Couldn't create gameManager script, we're buggered");
			}
		}
				}

	public void StartGame(string SceneName)
	{
		MainMenuUIParent.SetActive (false);
		SceneManager.LoadScene (SceneName);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void QuitGame()
	{
		SceneManager.LoadScene ("CreditScene");
	}
		
}
