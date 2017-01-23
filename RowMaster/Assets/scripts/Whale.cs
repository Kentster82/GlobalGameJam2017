using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour {
	
	void Activate()
	{
		transform.FindChild("whale bool").gameObject.active = true;
	}
	void SpawnWave()
	{
		this.transform.parent.gameObject.transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
	}
	void Deactivate()
	{
		transform.FindChild("whale bool").gameObject.active = false;
	}
}
