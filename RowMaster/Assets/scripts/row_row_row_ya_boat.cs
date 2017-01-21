using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class row_row_row_ya_boat : MonoBehaviour {
    Vector3 direction;
    public int force = 5;
	public bool flagged = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force *direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Right").position);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick1Button10))
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Right").position);

        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(direction, transform.Find("Left").position);

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            direction = transform.Find("Front").position - transform.position;
            direction = force * direction.normalized;
            //Debug.Log(direction);
            GetComponent<Rigidbody>().AddForceAtPosition(-direction, transform.Find("Left").position);

        }
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
