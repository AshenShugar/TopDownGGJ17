using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePart : MonoBehaviour {
    public float scale = 0.7f;
    public float fadeRate = 0.02f;
    // Use this for initialization
	void Start () {
        fadeRate = Mathf.Abs(fadeRate);
	}
	
	// Update is called once per frame
	void Update () {
        scale -= fadeRate;
        if (scale < 0.1f)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        transform.localScale = new Vector3(scale, scale, 1);

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1, 0.5f+scale/2, scale, Mathf.Sqrt(scale)/2);
        



	}
}
