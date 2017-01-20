using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityScript : MonoBehaviour {

	private float _timer;

	public float DarkenTimer = 0.25f;
	public float DarkenAmount = -0.1f;


	public void ChangeAlpha(float deltaAlpha)
	{
		SpriteRenderer SR = this.gameObject.GetComponent<SpriteRenderer> ();
		Color tmpColor = SR.color;

		tmpColor.a += deltaAlpha;

		if (tmpColor.a < 0)
			tmpColor.a = 0;

		if (tmpColor.a > 1)
			tmpColor.a = 1;

		SR.color = tmpColor;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;

		if (_timer >= DarkenTimer)
			ChangeAlpha (DarkenAmount);

	}
}
