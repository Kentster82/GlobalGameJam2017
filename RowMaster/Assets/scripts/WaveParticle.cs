﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour {
	public float force;
	public ParticleSystem waveGenerator;
	public List<ParticleCollisionEvent> collisionEvents;

	public int TimerTestInt = 0;

	void Awake () {
		waveGenerator = GetComponent<ParticleSystem> ();
		collisionEvents = new List<ParticleCollisionEvent> ();
		waveGenerator.Stop ();
	}

	void OnParticleCollision(GameObject other){
		int numCollisions = waveGenerator.GetCollisionEvents (other, collisionEvents);
		Rigidbody boat = other.GetComponent<Rigidbody> ();
		for (int i = 0; i < numCollisions; i++) {
			if (boat) {
				Vector3 particleForce = collisionEvents [i].velocity * force;
				boat.AddForce (particleForce);
			}
		}
	}

	void FixedUpdate(){
		TimerTestInt++;
		if(TimerTestInt > 200){
			waveGenerator.Emit (150);
			TimerTestInt = 0;
		}
	}
}