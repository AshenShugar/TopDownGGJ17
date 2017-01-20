using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoParticle : MonoBehaviour {

	public float ttl = 2.0f;

	private Vector3 _MovementDirection;

	public float ParticleSpeed;

	public Vector3 MovementDirection {
		get {
			return _MovementDirection;
		}
		set {
			_MovementDirection = value;
		}
	}
		
	void OnCollisionEnter2D(Collision2D aCollision)
	{
		VisibilityScript vScript = aCollision.gameObject.GetComponent<VisibilityScript> ();

		if (vScript != null)
			vScript.ChangeAlpha (0.5f);
		else {
			Debug.Log ("Didn't find a Visibility Script on something we ran into");
			Debug.Log (aCollision.gameObject.name);
		}
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, ttl);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (MovementDirection.normalized * ParticleSpeed * Time.deltaTime);
	}
}
