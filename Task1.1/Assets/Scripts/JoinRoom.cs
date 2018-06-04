using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinRoom : MonoBehaviour {
	
	public Button ok;
	public Text roomTitle;

	void Start()
	{
		Button btn = ok.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		roomTitle.text = PlayerPrefs.GetString("room");
	}

	void TaskOnClick()
	{
		Debug.Log("Back to list");
		LoadScene();
	}

	void LoadScene()
	{
		SceneManager.LoadScene("RoomList", LoadSceneMode.Single);
	}

}
