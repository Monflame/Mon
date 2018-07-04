using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
	public Vector3 fromPos;
	public Vector3 toPos;
	GameManager gameManager;
	GameObject HandEnemy;
	GameObject FieldEnemy;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
		HandEnemy = GameObject.Find("HandEnemy");
		FieldEnemy = GameObject.Find("FieldEnemy");
		fromPos = HandEnemy.transform.position;
		toPos = FieldEnemy.transform.position;
	}

	public IEnumerator EnemyCards()
	{
		for(int i = 0; i < gameManager.enemyList.Count; i = gameManager.enemyList.Count-1)
		{
			gameManager.enemyList[i].transform.position = Vector3.Lerp(fromPos, toPos, 100);
			gameManager.enemyList.Remove(gameManager.enemyList[i]);
			yield return new WaitForSeconds(1.5f);
		}
	}
}