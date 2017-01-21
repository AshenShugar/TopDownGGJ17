using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVisibilityScript : MonoBehaviour {

	[SerializeField]
	private VisibilityScript vScript;

	public float alphaChange = 0.5f;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D WhatEntered)
	{
		if (WhatEntered.gameObject.tag == "Echo") {
			vScript.ChangeAlpha (alphaChange);
		}
	}
}
