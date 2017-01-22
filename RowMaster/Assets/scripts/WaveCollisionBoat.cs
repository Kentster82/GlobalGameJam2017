/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionBoat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnParticleCollision(GameObject other){
		GetComponent<Rigidbody>().AddForceAtPosition((transform.position - other.gameObject.transform.position).normalized*other.gameObject.GetComponent<WaveParticle>().force,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

*/