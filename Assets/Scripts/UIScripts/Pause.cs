using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour {

	private bool isPaused;								//Boolean to check if the game is paused or not
	[SerializeField]
	private GameObject optionPanel;
	[SerializeField]
	private GameObject MainMenuPanel;

	[SerializeField]
	private string MenuSceneName;

	//Awake is called before Start()
	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

		//Check if the Cancel button in Input Manager is down this frame (default is Escape key) and that game is not paused, and that we're not in main menu
		if (Input.GetButtonDown ("Cancel") && !isPaused && SceneManager.GetActiveScene().name != MenuSceneName ) 
		{
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//If the button is pressed and the game is paused and not in main menu
		else if (Input.GetButtonDown ("Cancel") && isPaused && SceneManager.GetActiveScene().name != MenuSceneName) 
		{
			//Call the UnPause function to unpause the game
			UnPause ();
		}

		if (SceneManager.GetActiveScene().name == MenuSceneName ) {
			if(!MainMenuPanel.activeSelf)
				MainMenuPanel.SetActive (true);
		}
		else
			MainMenuPanel.SetActive (false);
		
	
	}

	public void QuitToMenu()
	{
		UnPause ();
		SceneManager.LoadScene (MenuSceneName);
		MainMenuPanel.SetActive (true);

		// trying to force the initial button to be highlighted, but just doesn't want to work
		/*
		Button[] tmpArray = MainMenuPanel.GetComponentsInChildren<Button> ();
		foreach (Button tmp in tmpArray) {
			if (tmp.gameObject.name == "StartGame") {

				EventSystem es = FindObjectOfType<EventSystem> ();

				es.SetSelectedGameObject (tmp.gameObject);

				tmp.Select ();
				tmp.OnSelect (null);
			}
		}

		*/
	}

	public void DoPause()
	{
		//Set isPaused to true
		isPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		//call the ShowPausePanel function of the ShowPanels script
		optionPanel.SetActive(true);
	}

	public void QuitToMenu(float inSeconds)
	{
		Invoke ("QuitToMenu", inSeconds);
	}

	public void UnPause()
	{
		//Set isPaused to false
		isPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		//call the HidePausePanel function of the ShowPanels script
		optionPanel.SetActive(false);
	}


}
