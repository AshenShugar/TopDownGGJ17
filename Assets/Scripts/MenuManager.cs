using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	private GameManager GM;

	[SerializeField]
	private Text NumberOfPlayersUI;
	[SerializeField]
	private GameObject optionPanel;

	[SerializeField]
	private string GameScene;


	public void ChangeNumberOfPlayers( int deltaNOP)
	{
		GM.NumberOfPlayers += deltaNOP;

		if (GM.NumberOfPlayers > GM.MaxNumberOfPlayers)
			GM.NumberOfPlayers = 2;

		if (GM.NumberOfPlayers == 1	)
			GM.NumberOfPlayers = GM.MaxNumberOfPlayers;

		// update UI
		NumberOfPlayersUI.text = GM.NumberOfPlayers.ToString();
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

		//NumberOfPlayersUI.text = GM.NumberOfPlayers.ToString ();
	}

	public void StartGame(){
		SceneManager.LoadScene (GameScene);
	}

	public void StartGame(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void QuitGame()
	{
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
