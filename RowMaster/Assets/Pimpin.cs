using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pimpin : MonoBehaviour {

	public int Raft1Score;
	public int Raft2Score;
	public int Raft3Score;
	public int Raft4Score;

	// Use this for initialization
	void Start () {
		Raft1Score = GameObject.Find ("Raft1").GetComponent<row_row_row_ya_boat>().score;
		Raft2Score = GameObject.Find ("Raft2").GetComponent<row_row_row_ya_boat>().score;
		Raft3Score = GameObject.Find ("Raft3").GetComponent<row_row_row_ya_boat>().score;
		Raft4Score = GameObject.Find ("Raft4").GetComponent<row_row_row_ya_boat>().score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
