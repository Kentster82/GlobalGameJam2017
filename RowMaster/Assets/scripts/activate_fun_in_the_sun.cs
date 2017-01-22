using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_fun_in_the_sun : MonoBehaviour {
    float time;
    int Case;
	// Use this for initialization
	void Start () {
        time = 0;
        Case = 0;
	}

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Debug.Log("Somethin works");
            time = Random.Range(1,5);
            Case = Random.Range(0, 7);
            switch (Case)
            {
                case 0:
                    GameObject.Find("WaveGenerator1").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 1:
                    GameObject.Find("WaveGenerator2").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 2:
                    GameObject.Find("WaveGenerator3").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 3:
                    GameObject.Find("WaveGenerator4").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 4:
                    GameObject.Find("WaveGenerator1").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator3").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 5:
                    GameObject.Find("WaveGenerator2").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator4").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 6:
                    GameObject.Find("WaveGenerator1").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator2").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator3").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator4").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 7:
                    GameObject.Find("WaveGenerator1").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator3").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                case 8:
                    GameObject.Find("WaveGenerator2").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    GameObject.Find("WaveGenerator4").transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                    break;
                default:
                    break;
            }
        
            
        }
    }
    // Update is called once per frame
    void Update () {
	    
	}

}
