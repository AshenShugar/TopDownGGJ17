using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public int NumberOfPlayers = 2;
	public int CurrentPlayer = 0;
	public int MaxNumberOfPlayers = 4;


	public string CurrentPlayerText {
		get {
			return (CurrentPlayer + 1).ToString ();
		}
	}

	public void NextPlayer()
	{
		CurrentPlayer++;
		if (CurrentPlayer >= NumberOfPlayers)
			CurrentPlayer = 0;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
