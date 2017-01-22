using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy1 : MonoBehaviour {
    GameObject target;


	[SerializeField]
	private bool EnemyAwake = false;
	[SerializeField]
	private float wakeUpRange = 7.0f;

	public void wakeUp ()
	{
		EnemyAwake = true;
	}

	// Use this for initialization
	void Start () {
		target = GameObject.Find("player");
        Physics2D.IgnoreLayerCollision(11, 12);
	}
    public float movementSpeed = 0.75f;
    // Update is called once per frame
    void Update () {
        /*
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float xo = target.transform.position.x;
        float yo = target.transform.position.y;
		*/

		if (target != null) {
			if ((target.transform.position - transform.position).magnitude <= wakeUpRange) {
				EnemyAwake = true;
			}
		}
        if (target != null && EnemyAwake)
        {
				
            /*
            double angle = UGameLogic.DirToPoint(x,y,xo,yo);
 
            double angleR = UGameLogic.TrueBearingsToRadians(angle);

            transform.position = new Vector3(x + (float)(movementSpeed * Math.Cos(angleR)), y + (float)(movementSpeed * Math.Sin(angleR)), z);
			*/
			transform.position = transform.position + (target.transform.position - transform.position).normalized * Time.deltaTime * movementSpeed;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, (target.transform.position - transform.position));


        }

	}
}
