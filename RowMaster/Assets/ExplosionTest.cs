using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour {	
	// Update is called once per frame
	private int frameCount = 0;
	public GameObject boat1;
	public GameObject boat2;

	void Update () {
		frameCount += 1;
		if(frameCount >= 600){
			boat1.GetComponent<Rigidbody> ().AddExplosionForce (1000.0f, transform.position, 25f, 3f);
			boat2.GetComponent<Rigidbody> ().AddExplosionForce (1000.0f, transform.position, 25, 3f);
			frameCount = 0;
		}
	}
}