using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour {

	public static int UnlockedLevels = 1;

	[SerializeField]
	Button[] buttons;

	[SerializeField]
	ScrollRect rect;

	[SerializeField]
	VerticalLayoutGroup layout;

	private int currentUnlockedLevels;
	private int totalLevels = 4;

	void Awake ()
	{
		
	}

	void Start ()
	{
		//PlayerPrefs.DeleteAll();
		GetUnlockedLevels();
		SetScrollRectPos();

	}

	void GetUnlockedLevels ()
	{
		if (PlayerPrefs.HasKey("unlockedLevels"))
		{
			currentUnlockedLevels = PlayerPrefs.GetInt("unlockedLevels");
		}
		else 
		{
			currentUnlockedLevels = 1;
		}
		print(currentUnlockedLevels);
		for (int i = 0; i < currentUnlockedLevels; i++)
		{
			buttons[i].interactable = true;
		}

		buttons[currentUnlockedLevels - 1].GetComponent<Animator>().enabled = true;

	}

	void SetScrollRectPos(){
		float totalHeight = layout.preferredHeight * totalLevels + layout.spacing * (totalLevels - 1) + layout.padding.vertical;
		float targetHeight = layout.preferredHeight * currentUnlockedLevels + layout.spacing * (currentUnlockedLevels - 1) + layout.padding.top;

		rect.verticalNormalizedPosition = (Mathf.Max(0f, targetHeight - rect.minHeight) / totalHeight); //no scrolling needed for initial visible in scrollRect, so subtract from targetHeight
		print(rect.verticalNormalizedPosition);
	}

	public void LoadLevel(string scene)
	{
		SceneManager.LoadScene(scene);

	}
}
