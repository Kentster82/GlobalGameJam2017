using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Its_over_9000 : MonoBehaviour {
    int time, time2;
    float angle, angleprev;
    Vector3 St;
	// Use this for initialization
	void Start () {
        time = 0;
        angle = 0;
        angleprev = 0;
	}

    private void FixedUpdate()
    {
        
        if(time == 0)
        {
            St = GetComponent<Rigidbody>().transform.Find("Front").position - transform.position;
        }
        else if(time <= 250)
        {
            Vector3 current = GetComponent<Rigidbody>().transform.Find("Front").position - transform.position;
            angle += Vector3.Angle(St,current);
            St = current;
            Debug.Log(angle);
            //Debug.Log(angleprev);
            if ( angle+angleprev >= 360 || angleprev+angle <= -360)
            {
                GetComponent<Rigidbody>().MovePosition(new Vector3(0,5,0));
            }
        }
        time++;
        if (time >= 250)
        {
            time = 0;
            angleprev = angle;
            angle = 0;
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
