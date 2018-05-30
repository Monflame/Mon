using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour {

	public Canvas roomObj;

	void Start ()
	{
		for(int i = 0; i < 5; i++)
		{
			Instantiate(roomObj, new Vector3(0,i+i,95), Quaternion.identity);
		}
    }
}
