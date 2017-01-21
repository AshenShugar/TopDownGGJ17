using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeathSoundHere : MonoBehaviour {
	[SerializeField]
	private AudioSource deathSFXplayer;
	[SerializeField]
	private AudioSource deathSFXenemy;
	private bool played;
	private int index;

	public void PlayAudioByIndex(int i)
	{
		index = i;
		AudioSource tmp = GetAS ();
		tmp.Play ();

	}

	private AudioSource GetAS()
	{
		played = true;
		switch (index) {
		case 0:
			{
				return deathSFXplayer;
			}
		case 1:
			{
				return deathSFXenemy;
			}
		default:
			return null;
		}
	}

	// Use this for initialization
	void Start () {
		played = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetAS ().isPlaying && played) {
			Destroy (this.gameObject);
		}
	}
}
