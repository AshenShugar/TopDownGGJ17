using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy1 : MonoBehaviour {
    GameObject target;
	// Use this for initialization
	void Start () {
		
	}
    public float movementSpeed = 0.05f;
    // Update is called once per frame
    void Update () {
        target = GameObject.Find("player");
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float xo = target.transform.position.x;
        float yo = target.transform.position.y;

        if (target != null)
        {
            double angle = UGameLogic.DirToPoint(x,y,xo,yo);
 
            double angleR = UGameLogic.TrueBearingsToRadians(angle);

            transform.position = new Vector3(x + (float)(movementSpeed * Math.Cos(angleR)), y + (float)(movementSpeed * Math.Sin(angleR)), z);
        }

	}
}
