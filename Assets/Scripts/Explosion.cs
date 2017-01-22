using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Explosion : MonoBehaviour {
    public float radius=0.1f;
    public float alpha = 1f;
    public float fadeRate = 0.01f;
    public float growRate = 0.05f;
    public float maxRadius = 2;
    public GameObject creator;

    public HashSet<GameObject> damagedObjects = new HashSet<GameObject>();
    void OnTriggerEnter2D(Collider2D WhatEntered)
    {
        GameObject other = WhatEntered.gameObject;
        if (other == creator)
        {
            return;
        }
        if (damagedObjects.Contains(other))
        {
            return;
        }
        ShowHealth healthScript = other.GetComponent<ShowHealth>();



        if (healthScript != null)
        {
            healthScript.Injure(25);
            damagedObjects.Add(other);

        }
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        radius = Math.Min(radius + growRate,maxRadius);
        transform.localScale = new Vector3(radius/2 , radius/2 , radius/2 );
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = 0.45f;

        if (radius >= maxRadius)
        {
            GameObject.Destroy(this.gameObject);

        }
	}
}
