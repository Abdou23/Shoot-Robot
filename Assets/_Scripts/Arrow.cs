using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour {


	public LevelManager levelManager;

	ArrowRotation rotation;
	private Vector3 position;
	// Use this for initialization
	void Start () 
	{
		position = gameObject.transform.position;
		rotation = GetComponent<ArrowRotation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "BadRobot")
		{
			Destroy(other.gameObject);
			//Destroy(gameObject);
			levelManager.RobotKilled();
		}
		else if (other.tag == "Wall")
		{
			SceneManager.LoadScene("Level-Selection");
		}
	}

	public void ResetArrow ()
	{
		//rotation.myBody.velocity = new Vector2(0, 0);
		rotation.stationary = true;
		gameObject.SetActive(false);
		gameObject.transform.position = position;
		gameObject.SetActive(true);
	}
}
