using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoParticle : MonoBehaviour {

	public float ttl = 2.0f;

	public float alphaChange = 0.5f;

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
		
	// Change the alpha to make whatever we collided with more visible.
	void OnCollisionEnter2D(Collision2D aCollision)
	{
		VisibilityScript vScript = aCollision.gameObject.GetComponent<VisibilityScript> ();

		if (vScript != null)
			vScript.ChangeAlpha (alphaChange);
		else {
			// Project Physics2D settings should ensure only things with VisibilityScript's can collide.
			Debug.Log ("Didn't find a Visibility Script on something we ran into");
			Debug.Log (aCollision.gameObject.name);
		}
        Enemy1 enemy1 = aCollision.gameObject.GetComponent<Enemy1>();
        ShowHealth healthScript= aCollision.gameObject.GetComponent<ShowHealth>();
        if (enemy1 != null && healthScript!=null)
        {

            healthScript.Injure(1);
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
