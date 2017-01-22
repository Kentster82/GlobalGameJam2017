using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour {	
	private Vector3 origin;
	public int id;
	public float force;
	public float radius;
	public float upwardBumpForce;

	void Start () {
		origin = transform.position;
	}

	void OnParticleCollision(GameObject other){

	}

	void Update () {
	}
}