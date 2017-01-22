using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row_row_row_ya_boat : MonoBehaviour {
    Vector3 direction;
    public int force;
	public bool flagged = false;
    bool OldTriggerStateR , OldTriggerStateL;
    public string JoyNum;
    KeyCode RB, LB;
    Vector3 Bouyant = new Vector3(0, 9.81f, 0);
    // Use this for initialization
    void Start () {
        OldTriggerStateR =false;
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
            force = 75;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(RB))
        {
           direction = transform.Find("Front").position - transform.position;
           direction = force *direction.normalized;
           //Debug.Log(direction);
           GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Right").position);

        }
        if (TriggerR)
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Right").position);

        }
    
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(LB))
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Left").position);

        }
        if ( TriggerL)
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Left").position);

        }
        OldTriggerStateR = NewTriggerStateR;
        OldTriggerStateL = NewTriggerStateL;
        force = 50;
    }

    void Update () {
      
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "flag")
		{
			flagged = true;
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "player")
		{
			if (flagged)
				flagged = false;
			if (!flagged)
			{
				if (collision.gameObject.GetComponent<row_row_row_ya_boat>().flagged)
				{
					flagged = true;
					// Generate wave
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
