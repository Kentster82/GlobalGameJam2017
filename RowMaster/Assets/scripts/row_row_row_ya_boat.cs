using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class row_row_row_ya_boat : MonoBehaviour {
	public Animator leftAnimator;
	public Animator rightAnimator;

	public string JoyNum;
    public int force;
	public bool flagged = false;
	public int score = 0;
	float time = 0;
	public int winThreshold;
	public string GameEndScene;

	Vector3 direction;
    bool OldTriggerStateR , OldTriggerStateL;
    KeyCode RB, LB;
    Vector3 Bouyant = new Vector3(0, 9.81f, 0);

	int wait = 0;
    // Use this for initialization
    void Start () {
        OldTriggerStateR =false;
        //GameObject.Find("Cheers").GetComponent<AudioSource>().Pause();
        switch (JoyNum)
        {
            case "Joystick1":
                RB = KeyCode.Joystick1Button5;
                LB = KeyCode.Joystick1Button4;
                break;
            case "Joystick2":
                RB = KeyCode.Joystick2Button5;
                LB = KeyCode.Joystick2Button4;
                break;
            case "Joystick3":
                RB = KeyCode.Joystick3Button5;
                LB = KeyCode.Joystick3Button4;
                break;
            case "Joystick4":
                RB = KeyCode.Joystick4Button5;
                LB = KeyCode.Joystick4Button4;
                break;
            default:
                break;
        }

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        bool NewTriggerStateR = Input.GetAxis(JoyNum + "AxisRight") > 0f;
        bool NewTriggerStateL = Input.GetAxis(JoyNum + "AxisLeft") > 0f;
        bool TriggerR = (!OldTriggerStateR && NewTriggerStateR);
        bool TriggerL = (!OldTriggerStateL && NewTriggerStateL);

        if (transform.position.y <= 0)
        {
            
            GetComponent<Rigidbody>().AddForceAtPosition(Bouyant * -(transform.position.y- GetComponent<Rigidbody>().mass),transform.position);
        }
        if(Input.GetKeyDown(RB) && Input.GetKeyDown(LB) || Input.GetKeyDown(RB) && TriggerL || Input.GetKeyDown(LB) && TriggerR || TriggerL && TriggerR)
        {
            force = 60;
            //Debug.Log("NICE!");
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Right").position);
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Left").position);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(RB))
        {
			rightAnimator.SetTrigger ("Forward");
           direction = transform.Find("Front").position - transform.position;
           direction = force *direction.normalized;
           //Debug.Log("RB");
           GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Right").position);

        }
        if (TriggerR || Input.GetKeyDown(KeyCode.DownArrow))
        {
			rightAnimator.SetTrigger ("Backward");
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Right").position);

        }
    
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(LB))
        {
			leftAnimator.SetTrigger ("Forward");
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log("LB");
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Left").position);

        }
        if ( TriggerL || Input.GetKeyDown(KeyCode.S))
        {
			leftAnimator.SetTrigger ("Backward");
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Left").position);

        }
        OldTriggerStateR = NewTriggerStateR;
        OldTriggerStateL = NewTriggerStateL;
        force = 75;
    }

    void Update () {
		if (flagged)
		{
			this.gameObject.transform.Find ("FlagObject").gameObject.SetActive (true);
			this.gameObject.transform.Find ("flag indicator").gameObject.SetActive (true);
			wait = 20;
		}
		if (!flagged)
		{
			this.gameObject.transform.Find ("FlagObject").gameObject.SetActive (false);
			this.gameObject.transform.Find ("flag indicator").gameObject.SetActive (false);
		}
		if (wait >= 0)
			wait--;

		/*
		if (flagged) {
			time += Time.deltaTime;
			score = (int)time;
			if (this.gameObject.name == "Raft1")
				GameObject.Find ("GamePimp").GetComponent<Pimpin> ().Raft1Score = score;
			if (this.gameObject.name == "Raft2")
				GameObject.Find ("GamePimp").GetComponent<Pimpin> ().Raft2Score = score;
			if (this.gameObject.name == "Raft3")
				GameObject.Find ("GamePimp").GetComponent<Pimpin> ().Raft3Score = score;
			if (this.gameObject.name == "Raft4")
				GameObject.Find ("GamePimp").GetComponent<Pimpin> ().Raft4Score = score;
			if (score >= winThreshold){
				flagged = false;
				SceneManager.LoadSceneAsync(GameEndScene);
			}
		}
		*/
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "flag")
		{
			flagged = true;
			Destroy(collision.gameObject);
		}
		//Debug.Log ("I hit something");

		if (collision.gameObject.tag == "Player")
		{
			//if (flagged)
			//	flagged = false;
			//Debug.Log("I hit a player");
			if (!flagged)
			{
				if (wait <= 0)
				{
				//Debug.Log("I'm not flagged");
					if (collision.gameObject.GetComponent<row_row_row_ya_boat>().flagged)
					{
					//Debug.Log ("They're not flagged, so i'm gonna transfer shit");
						flagged = true;
						collision.gameObject.GetComponent<row_row_row_ya_boat>().flagged = false;
                        this.transform.FindChild("WaveGenerator").GetComponent<ParticleSystem>().Emit(150);
                        //GameObject.Find("Cheers").GetComponent<AudioSource>().Play();
						//GameObject.Find("SplishSplashTakinABath").GetComponent<AudioSource>().Play();
                        //Debug.Log("I transfered shit");
                    }
				}
			}
		}
		if (collision.gameObject.tag == "wave")
		{
			if (flagged)
			{
				flagged = false;
				// Spawn Flag
			}
		}
			
	}

}
