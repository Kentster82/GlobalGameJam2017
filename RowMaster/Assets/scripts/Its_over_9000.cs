using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Its_over_9000 : MonoBehaviour {
    int time, time2,count;
    float angle, angleprev,anglesum;
    //bool NE,NW,SE,SW, NE2, SE2, NW2, SW2;
    bool POWER;
    Vector3 last, first;
    float[] Angles, Deltas; 
	// Use this for initialization
	void Start () {
        POWER = false;
        Angles = new float[300];
        Deltas = new float[300];
        time = 0;
        angle = 0;
        angleprev = 0;
        anglesum = 0;
        count = 0;
	}

    private void FixedUpdate()
    {
        
        if(time == 0)
        {
            last = GetComponent<Rigidbody>().transform.Find("Front").position - transform.position;
        }
        else if(time <= 250)
        {

            Vector3 current = GetComponent<Rigidbody>().transform.Find("Front").position - transform.position;
            current=current.normalized;
            angle = Vector3.Angle(Vector3.forward, current);
            Angles[time] = angle;
            Deltas[time] = Angles[time] - angleprev;
            //Debug.Log(Deltas[time]);
            anglesum += Vector3.Angle(last, current);
            if (time == 1)
            {
                time++;
                return;
            }
            if(!(Deltas[time]*Deltas[time-1] > 0))
            {
                //Debug.Log("Switched");
                count++;
                if (count >= 10)
                {
                    //Debug.Log("missed it");
                    count = 0;
                    time = 0;
                    angle = 0;
                    anglesum = 0;
                    angleprev = 0;
                    return;
                }
            }
            Debug.Log(anglesum);
            //setbools(current);
            last = current;
            //Debug.Log(angle);
            //Debug.Log(angleprev);
            if ( anglesum + (angleprev-(time/2)) >= 360)
            {
                //GetComponent<Rigidbody>().MovePosition(new Vector3(0, 5, 0));
                POWER = true;
                count = 0;
                time = 0;
                angle = 0;
                anglesum = 0;
                angleprev = 0;
            }
            angleprev = angle;
        }
        time++;
        if (time >= 275)
        {
            time = 0;
            angleprev = anglesum;
            anglesum = 0;
            angle = 0;
        }
        
    }
    // Update is called once per frame
    //void setbools(Vector3 V)
    //{
    //    if (V.x > 0 && V.z > 0)
    //    {
    //        NE = true;
    //    }
    //    else if (V.x > 0 && V.z < 0)
    //    {
    //        SE = true;
    //    }
    //    else if (V.x < 0 && V.z > 0)
    //    {
    //        NW = true;
    //    }
    //    else if (V.x < 0 && V.z < 0)
    //    {
    //        SW = true;
    //    }
    //    else {
    //    }
    //}
    void Update () {
        if (POWER)
        {
            //Vector3 front = GetComponent<Rigidbody>().transform.Find("Front").position - transform.position;
            
        }
	}
}
