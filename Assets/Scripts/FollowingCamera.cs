using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {
    GameObject following;
	// Use this for initialization
	void Awake () {
        following = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = following.transform.position;
        transform.position = new Vector3(pos.x, pos.y, -10);
	}
}
