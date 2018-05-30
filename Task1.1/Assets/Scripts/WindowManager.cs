using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour {

	public Dropdown dropdown;
	List<string> dropOptions = new List<string> {"Casino", "Bingo"};
	public Text dropText;
	public Image room;

	void Start()
	{
		/*switch(dropdown.value){
			case 0:
				room.gameObject.SetActive(false);
				Debug.Log("result =" +dropdown.value);
				break;
			case 1:
				room.gameObject.SetActive(true);
				Debug.Log("result =" +dropdown.value);
				break;
		}*/
		dropdown = GetComponent<Dropdown>();
		dropdown.ClearOptions();
		dropdown.AddOptions(dropOptions);
	}
	
		/*switch(dropdown.value){
			case 0:
				room.gameObject.SetActive(false);
				Debug.Log("result =" +dropdown.value);
				break;
			case 1:
				room.gameObject.SetActive(true);
				Debug.Log("result =" +dropdown.value);
				break;
		}*/	
}
