using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomList : MonoBehaviour {

	public Button join;
	public Text roomName;

	void Start()
	{
		Button btn = join.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("Loading");
		PlayerPrefs.SetString("room", roomName.text);
		LoadScene();
	}

	void LoadScene()
	{
		SceneManager.LoadScene("JoinRoom", LoadSceneMode.Single);
	}
}
