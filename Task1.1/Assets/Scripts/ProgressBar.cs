using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
	public Slider progressBar;
	public Text progressText;
	public Image full;

	void Start()
	{
		full.gameObject.SetActive(false);
		progressBar.value = Mathf.Clamp(Random.Range (1, 300), 0, 255);
		progressText.text = progressBar.value.ToString() +"/255";
		if(progressBar.value >= 255)
			full.gameObject.SetActive(true);
	}
}
