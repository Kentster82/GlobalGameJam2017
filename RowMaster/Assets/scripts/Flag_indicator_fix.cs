using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_indicator_fix : MonoBehaviour {
	Vector3 direction;
	Quaternion spin;
	// Use this for initialization
	void Start (){
	}

	void FixedUpdate(){
		direction= transform.parent.transform.position;
		transform.position = new Vector3(direction.x, direction.y, direction.z+4);
		transform.eulerAngles = new Vector3 (70, 0, 0);
		}
	// Update is called once per frame
	void Update () {
		
	}
}
