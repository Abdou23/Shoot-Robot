using UnityEngine;
using System.Collections;

public class ArrowRotation : MonoBehaviour {

	public float speed = 20;

	public Rigidbody2D myBody;
	public bool stationary = true;

	// Use this for initialization
	void Start () 
	{
		myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (stationary)
		{
			transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * 2) * 60); 

		}

		if (Input.GetMouseButtonDown(0)) 
		{
			stationary = false;
			myBody.velocity = transform.up  * speed;

		}

	}
}
