using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour {


	public float speed = 5;

	[SerializeField] 
	bool left;

	private Rigidbody2D myBody;
	// Use this for initialization
	void Start () 
	{
		myBody = GetComponent<Rigidbody2D>();
		//left = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (left)
		{
			myBody.velocity = -transform.right * speed;
		}
		else 
		{
			myBody.velocity = transform.right * speed;	
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Wall")
		{
			left = !left;
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			myBody.velocity = transform.right * speed;

		}
	}

}
