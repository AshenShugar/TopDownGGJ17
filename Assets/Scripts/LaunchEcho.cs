using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchEcho : MonoBehaviour {

	[SerializeField]
	private GameObject EchoParticleObject;

	public int NumberOfEchoParticles;

	public int angleOffFoward = 30;

	private float DegreeInRadians;

	public void LaunchEchoLocation()
	{
		Quaternion angleOfLaunch;
		float x, y;
		Vector3 LaunchVector;
		GameObject tmpObj;

		x = Mathf.Sin (DegreeInRadians * (angleOffFoward * 2) / NumberOfEchoParticles );
		y = Mathf.Cos (DegreeInRadians * (angleOffFoward * 2) / NumberOfEchoParticles );

		LaunchVector.x = x;
		LaunchVector.y = y;
		LaunchVector.z = 0;

		angleOfLaunch = Quaternion.FromToRotation (Vector3.up, LaunchVector);

		LaunchVector = Vector3.up;

		for (int i = 0; i < NumberOfEchoParticles * 0.5; i++) {
			tmpObj = Instantiate (EchoParticleObject, this.gameObject.transform.position + transform.rotation * LaunchVector, transform.rotation);
			EchoParticle tmpEP = tmpObj.GetComponent<EchoParticle> ();

			tmpEP.MovementDirection = transform.rotation * LaunchVector;
			LaunchVector = angleOfLaunch * LaunchVector;
		}

		LaunchVector = Vector3.up;
		angleOfLaunch = Quaternion.Inverse (angleOfLaunch);

		for (int i = 0; i < NumberOfEchoParticles * 0.5; i++) {
			tmpObj = Instantiate (EchoParticleObject, this.gameObject.transform.position + transform.rotation * LaunchVector, transform.rotation);
			EchoParticle tmpEP = tmpObj.GetComponent<EchoParticle> ();

			tmpEP.MovementDirection = transform.rotation * LaunchVector;
			LaunchVector = angleOfLaunch * LaunchVector;
		}
	}

	// Use this for initialization
	void Start () {
		DegreeInRadians = Mathf.PI / 180;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") > 0) {
			LaunchEchoLocation ();
		}
	}
}
