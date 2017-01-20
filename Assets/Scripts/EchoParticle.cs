using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoParticle : MonoBehaviour {


	private Vector3 _MovementDirection;


	public Vector3 MovementDirection {
		get {
			return _MovementDirection;
		}
		set {
			_MovementDirection = value;
		}
	}

	public EchoParticle( Vector3 initialDirection)
	{
		MovementDirection = initialDirection;
	}

	void OnCollisionEnter(Collision aCollision)
	{
		VisibilityScript vScript = aCollision.gameObject.GetComponent<VisibilityScript> ();

		vScript.ChangeAlpha (0.5f);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (MovementDirection * Time.deltaTime);
	}
}
