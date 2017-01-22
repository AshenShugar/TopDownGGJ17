using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour {

	public float TimeToLive = 5;

	private float _timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;

		if (_timer > TimeToLive) {
			//If we are running in a standalone build of the game
			#if UNITY_STANDALONE
			//Quit the application
			Application.Quit();
			#endif

			//If we are running in the editor
			#if UNITY_EDITOR
			//Stop playing the scene
			UnityEditor.EditorApplication.isPlaying = false;
			#endif		
		}
	}
}
