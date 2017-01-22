using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pimpin : MonoBehaviour {
    public int offset1 = 13;
    public int offset2 = 72;

    string P1Text = "P1 SCORE";
    string P2Text = "P2 SCORE";


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Label(new Rect(offset1*Screen.width / 100, 20, Screen.width / 4, 20), P1Text);
        GUI.Label(new Rect(offset2*Screen.width / 100, 20, Screen.width, 20), P2Text);
    }
}
