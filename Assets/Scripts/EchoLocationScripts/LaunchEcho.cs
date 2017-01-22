using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchEcho : MonoBehaviour {

	[SerializeField]
	private GameObject EchoParticleObject;

	[SerializeField]
	private GameObject rocket;

	public int NumberOfEchoParticles;

	public int angleOffFoward = 30;

	private float DegreeInRadians;

	[SerializeField]
	private AudioSource SonarEffect;


	public void LaunchMissile()
	{
		GameObject tmpObj;

		tmpObj = Instantiate(rocket, this.gameObject.transform.position, transform.rotation);
		Rocket r = tmpObj.GetComponent<Rocket>();
		Vector3 eulerAngle = transform.eulerAngles;
		double angle = 360 - transform.eulerAngles.z;
		r.angle = angle;
        r.waveSize = Mathf.Max(60 - missileCharge, 0)*2.25f / 60+0.25f;
		r.creator = this.gameObject;
        r.AdjustSpeed();

	}

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
		SonarEffect.Play ();


    }

	// Use this for initialization
	void Start () {
		DegreeInRadians = Mathf.PI / 180;
	}
    int missileCharge = 0;
	// Update is called once per frame
	void Update () {
        delayBeforeFire--;
        delayBeforeFireMissile--;
        if (delayBeforeFire < 0)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                LaunchEchoLocation();
                delayBeforeFire = maxDelayBeforeFire;
            }



        }
        if (delayBeforeFireMissile < 0)
        {
            if (Input.GetAxis("Fire2") > 0)
            {
                missileCharge++;

            }
            else if (missileCharge > 0)
            {
                LaunchMissile();
                missileCharge = 0;
                delayBeforeFireMissile = maxDelayBeforeFireMissile;
            }

        }

    }

    public int delayBeforeFire = UGameLogic.lengthOfSecond;
    public int maxDelayBeforeFire = UGameLogic.lengthOfSecond/3;

    public int delayBeforeFireMissile = UGameLogic.lengthOfSecond;
    public int maxDelayBeforeFireMissile = UGameLogic.lengthOfSecond*2 / 3;



}
