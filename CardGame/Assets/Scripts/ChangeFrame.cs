using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFrame : MonoBehaviour {

	Image _raw;
	public Sprite[] _texture;
	public Button s_button, c_button, l_button;

	void Start()
	{
		Button btn1 = s_button.GetComponent<Button>();
		btn1.onClick.AddListener(TaskSimple);

		Button btn2 = c_button.GetComponent<Button>();
		btn2.onClick.AddListener(TaskCraft);

		Button btn3 = l_button.GetComponent<Button>();
		btn3.onClick.AddListener(TaskLegendary);
	}

	void TaskSimple()
	{
		_raw = GetComponent<Image>();
		_raw.sprite = _texture[0];
	}

	void TaskCraft()
	{
		_raw = GetComponent<Image>();
		_raw.sprite = _texture[1];
	}

	void TaskLegendary()
	{
		_raw = GetComponent<Image>();
		_raw.sprite = _texture[2];
	}
}
