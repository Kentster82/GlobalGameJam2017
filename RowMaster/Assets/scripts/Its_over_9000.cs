using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Its_over_9000 : MonoBehaviour {
    int time;
    Quaternion start;
	// Use this for initialization
	void Start () {
        time = 0;
	}

    private void FixedUpdate()
    {
        time++;
        if(time == 0)
        {
            start = GetComponent<Rigidbody>().rotation;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
