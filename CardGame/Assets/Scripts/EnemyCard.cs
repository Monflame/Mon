using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCard : MonoBehaviour {
	
	GameManager gameManager;
	public GameObject cardPref;

	void Awake()
	{
		cardPref = GameObject.Find("CardPref");
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update()
	{
		if(!gameManager.IsPlayerTurn)
		{
			cardPref.transform.position = new Vector3(0, -1, 0);
		}
	}
}
