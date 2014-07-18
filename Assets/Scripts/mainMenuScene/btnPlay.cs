using UnityEngine;
using System.Collections;

public class btnPlay : MonoBehaviour {

	public GameObject btnPlayGoj;

	public int sceneIndex;
	public UILabel progressText;


	void Start()
	{
		UIEventListener.Get (btnPlayGoj).onClick += LoadLevel;
	}

	void LoadLevel (GameObject go)
	{
		InvokeRepeating("LoadGame", 0f, 2f);
	}

	void LoadGame()
	{
		//the game scene is ready
		if (Application.CanStreamedLevelBeLoaded(sceneIndex))
		{
			//set progress to 100, so that gets displayed while switching scenes 
			progressText.text = 100 + "%";
			//load the game scene
			Application.LoadLevel(sceneIndex);
		}
		else
		{
			//we're still loading the game scene, get the current progress and store it
			progressText.text = ((int)(Application.GetStreamProgressForLevel(sceneIndex) * 100)) + "%";
		}
	}
}
