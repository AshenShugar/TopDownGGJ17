using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class Rocket: MonoBehaviour
{
    double angle;
    float speed = 5;
    GameObject creator;
    public void Update()
    {
        double angleR = UGameLogic.TrueBearingsToRadians(angle);
        Vector3 pos = transform.position;
        float ofs = speed * Time.deltaTime;
        transform.position = new Vector3(pos.x+ofs*(float)Math.Cos(angleR), pos.y+ofs*(float)Math.Sin(angleR), pos.z);

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
            healthScript.Injure(20);
        else
        {

        }

        if ( healthScript != null)
        {

            healthScript.Injure(1);
        }
        Destroy(this.gameObject);

    }

}