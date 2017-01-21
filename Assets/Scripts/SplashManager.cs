using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {
	private float _ftimer;

	[SerializeField]
	private GameObject MenuUIParent;

	[SerializeField]
	private float _timeLimit;

	[SerializeField]
	private string _NextScene;

	// Use this for initialization
	void Start () {
		_ftimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_ftimer += Time.deltaTime;

		if (_ftimer > _timeLimit) {
			SceneManager.LoadScene (_NextScene);
			MenuUIParent.SetActive (true);
		}
	}
}
