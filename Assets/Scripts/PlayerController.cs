﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rb;

	public float playerSpeed = 200.0f;
	public float playerBreaking = 0.1f;

	[SerializeField]
	private bool SharpHandling = true;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		Quaternion PlayerRotation;
		Vector3 vPlayerVelocity;

		if (x != 0 || y != 0) {

			vPlayerVelocity.x = x;
			vPlayerVelocity.y = y;
			vPlayerVelocity.z = 0;

			vPlayerVelocity.Normalize ();

			if (SharpHandling) {
				_rb.velocity = (Vector2)vPlayerVelocity * Time.fixedDeltaTime * playerSpeed;
			} else {
				_rb.velocity += (Vector2)vPlayerVelocity * Time.fixedDeltaTime * playerSpeed;
			}
		} else {
			// slow the player down gently if they're moving
			vPlayerVelocity = _rb.velocity * playerBreaking;
			_rb.velocity = vPlayerVelocity;
		}

		if (_rb.velocity != Vector2.zero) {
			vPlayerVelocity = _rb.velocity;
			vPlayerVelocity.z = 0;
			// LookRotation assumes the positive z direction is what you want to be facing what you're looking at
			// That's not the case in 2d.  In 2d, z should always be up (or down or something), so set that to be what we look at,
			// and then use the LookRotations "up", to be what is actualy the 2d players forward direction.
			PlayerRotation = Quaternion.LookRotation (Vector3.back, vPlayerVelocity);

			transform.rotation = PlayerRotation;
		}

	}
}