﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class Rocket: MonoBehaviour
{
    public double angle;
    public float speed = 10;
    public float waveSize = 1;
    public GameObject creator;
    public Vector3 offset = new Vector3(0, 0, 0);
    int step = 0;
    public GameObject particleToSpawn;
    public int delayBeforeParticleSpawn = 0;
    public int maxDelayBeforeParticleSpawn = UGameLogic.lengthOfSecond / 4;
    public GameObject explosion;
    public void Awake()
    {
        AdjustSpeed();

    }

    public void AdjustSpeed()
    {
        speed = speed / (1 + waveSize/2);
        //Debug.Log("speed " + speed);
    }

    public void Update()
    {
        step++;

        
        double angleR = UGameLogic.TrueBearingsToRadians(angle);
        
        double angleR2 = UGameLogic.TrueBearingsToRadians(angle+90);
        Vector3 originalPos = transform.position;
        Vector3 pos = originalPos;
        float ofs = speed * Time.deltaTime;
        float ofs2 = waveSize*(float)Math.Sin((float)(step/10f));
        transform.position = new Vector3(pos.x+ofs*(float)Math.Cos(angleR), pos.y+ofs*(float)Math.Sin(angleR), pos.z);
         pos = transform.position;
        Vector3 prevOffset = offset;
        Vector3 nextOffset= new Vector3( ofs2 * (float)Math.Cos(angleR2), ofs2 * (float)Math.Sin(angleR2), pos.z);
        offset = nextOffset - prevOffset;

        transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y, pos.z);

        float newRot=(float)UGameLogic.DirToPoint(originalPos.x, originalPos.y, transform.position.x, transform.position.y);
        transform.eulerAngles = new Vector3(0, 0, -newRot);
        offset = nextOffset;
        //Debug.Log(new Vector3(ofs2 * (float)Math.Cos(angleR2), ofs2 * (float)Math.Sin(angleR2), pos.z)+"prevOffset"+prevOffset+"offset"+offset);
        //Spawn smoke
        delayBeforeParticleSpawn--;

        if (delayBeforeParticleSpawn < 0)
        {
            GameObject o=GameObject.Instantiate(particleToSpawn);
            o.transform.position = transform.position;
          
        }
    }

    // Change the alpha to make whatever we collided with more visible.
    void OnCollisionEnter2D(Collision2D aCollision)
    {
        if (aCollision.gameObject == creator)
        {
            return;
        }
        ShowHealth healthScript = aCollision.gameObject.GetComponent<ShowHealth>();


        if (healthScript != null)
            healthScript.Injure(30);
        else
        {

        }


        GameObject ex=GameObject.Instantiate(explosion);
        ex.transform.position = this.transform.position;
        Explosion ex_s = ex.GetComponent<Explosion>();
        ex_s.creator = this.creator;
        Destroy(this.gameObject);

    }

}