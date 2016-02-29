using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	GameObject arrow;

	[SerializeField]
	int totalRobots;

	[SerializeField]
	int nextLevel;

	[SerializeField]
	Text robotCount;

	[SerializeField]
	List<GameObject> walls;

	private int currentRobots = 0;

	void Start ()
	{
		robotCount.text = (currentRobots + "/" + totalRobots );
	}

	public void RobotKilled ()
	{
		currentRobots++;
		robotCount.text = (currentRobots + "/" + totalRobots );

		if (currentRobots == totalRobots)
		{
			LoadScene();
		}
		else 
		{
			Continue();
		}
	}

	void Continue()
	{
		Destroy(walls[0]);
		walls.RemoveAt(0);

		Arrow arrowScript = arrow.GetComponent<Arrow>();
		arrowScript.ResetArrow();

	}

	public void LoadScene ()
	{
 			SceneManager.LoadScene("Level-Selection");
			PlayerPrefs.SetInt("unlockedLevels", nextLevel);
			LevelSelectionManager.UnlockedLevels++;
	}

}
