using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityScript : MonoBehaviour {

	private float _timer;

	public float DarkenTimer = 0.05f;
	public float DarkenAmount = -0.05f;

	public float MinimumAlpha = 0f;

	private bool DarkEnough = true;


	public void ChangeAlpha(float deltaAlpha)
	{
		SpriteRenderer SR = this.gameObject.GetComponent<SpriteRenderer> ();
		Color tmpColor = SR.color;

		tmpColor.a += deltaAlpha;

		if (tmpColor.a <= MinimumAlpha) {
			tmpColor.a = MinimumAlpha;
			DarkEnough = true;
		} else {
			DarkEnough = false;
		}


		if (tmpColor.a > 1)
			tmpColor.a = 1;

		SR.color = tmpColor;

	}

	// Use this for initialization
	void Start () {

		#if !UNITY_EDITOR
		// Initially, the level should be invisible, and it's only once you've echo-located stuff that it should appear
		SpriteRenderer SR = this.gameObject.GetComponent<SpriteRenderer> ();
		Color tmpColor = SR.color;

		tmpColor.a = 0;

		SR.color = tmpColor;
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if (!DarkEnough) {
			_timer += Time.deltaTime;

			if (_timer >= DarkenTimer) {
				ChangeAlpha (DarkenAmount);
				_timer = 0;
			}
		}
	}
}
