using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
	public Vector3 fromPos;
	public Vector3 toPos;
	GameManager gameManager;
	public Transform HandEnemy;
	public Transform FieldEnemy;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
		fromPos = HandEnemy.transform.position;
		toPos = FieldEnemy.transform.position;
	}

	public IEnumerator EnemyCards()
	{
		for(int i = 0; i < gameManager.enemyList.Count; i = gameManager.enemyList.Count-1)
		{
			gameManager.enemyList[i].transform.position = Vector3.Lerp(fromPos, toPos, 0.5f);
			gameManager.enemyList.Remove(gameManager.enemyList[i]);
			yield return new WaitForSeconds(1);
		}
	}

	/*private void Update()
	{
		if(!gameManager.IsPlayerTurn)
			Move();
	}

	private void Move()
	{
		gameManager.enemyList[1].transform.position = Vector2.MoveTowards(fromPos, toPos, 1 * Time.deltaTime);
	}*/
}