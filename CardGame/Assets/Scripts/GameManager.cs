using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPull
{
	public List<CardObj> DeckSelf, DeckEnemy,
						HandSelf, HandEnemy,
						Fieldself, FieldEnemy;

	public CardPull()
	{
		DeckSelf = GetDeckCards();
		DeckEnemy = GetDeckCards();
		HandSelf = new List<CardObj>();
		HandEnemy = new List<CardObj>();
		Fieldself = new List<CardObj>();
		FieldEnemy = new List<CardObj>();
	}

	List<CardObj> GetDeckCards() //random set of cards from CardList
	{
		List<CardObj> list = new List<CardObj>();
		for(int i = 0; i < 10; i++)
			list.Add(CardList.AllCards[Random.Range(0,CardList.AllCards.Count)]);
		return list; //returns a random set of cards, everytime when it's used
	}
}

public class GameManager : MonoBehaviour {

	public CardPull CurrentPull;
	public Transform HandSelf, HandEnemy;
	public GameObject CardPref;
	int Turn, TurnTime = 30;
	public TextMeshProUGUI TurnTimeText;
	public Button EndTurnBtn;
	public int counterSelf;
	public int counterEnemy;

	public bool IsPlayerTurn
	{
		get
		{
			return Turn % 2 == 0;
		}
	}

	public bool IsEnemyTurn
	{
		get
		{
			return Turn % 2 == 1;
		}
	}

	void Start()
	{
		Turn = 0; //the Player's turn
		CurrentPull = new CardPull();

		GetHandCards(CurrentPull.DeckEnemy, HandEnemy); //give start set for enemy from random deck list
		GetHandCards(CurrentPull.DeckSelf, HandSelf); //the same is for Player
		StartCoroutine(TurnFunc()); //init turn/timer
	}

	void GetHandCards(List<CardObj> deck, Transform hand)
	{
		int i = 0;
		while(i++ <5) //count 5 items
			GetCardToHand(deck, hand);
			counterSelf = i;
			counterEnemy = i;
			Debug.Log(counterSelf + " : " + counterEnemy);
	}

	void GetCardToHand(List<CardObj> deck, Transform hand)
	{
		if(deck.Count == 0) //if count of items is 0, then exit
			return;

		CardObj card = deck[0]; //item is equal to an item_from_random_set

		GameObject cardGO = Instantiate(CardPref, hand, false); //spawn object's clones onto some layer

		if(hand == HandEnemy)
			cardGO.GetComponent<CardDisplay>().HideCardInfo(card); //doesn't use yet
		else
			cardGO.GetComponent<CardDisplay>().ShowCardInfo(card); //display's all card info

		deck.RemoveAt(0); //stop when there'is 0 items in the set
	}

	IEnumerator TurnFunc()
	{
		TurnTime = 20;
		TurnTimeText.text = TurnTime.ToString();

		if(IsPlayerTurn)
		{
			while(TurnTime-- > 0)
			{
				TurnTimeText.text = TurnTime.ToString();
				yield return new WaitForSeconds(1);
			}
		}
		else
		{
			while(TurnTime-- > 0)
			{
				TurnTimeText.text = TurnTime.ToString();
				yield return new WaitForSeconds(1);
			}
		}

		ChangeTurn();
	}

	public void ChangeTurn()
	{
		StopAllCoroutines();
		Turn++;
		EndTurnBtn.interactable = IsPlayerTurn;
		if(IsPlayerTurn)
			AddNewCard();
		StartCoroutine(TurnFunc());
	}

	void AddNewCard()
	{
		GetCardToHand(CurrentPull.DeckEnemy, HandEnemy);
		counterEnemy++;
		GetCardToHand(CurrentPull.DeckSelf, HandSelf);
		counterSelf++;
		Debug.Log(counterSelf + " : " + counterEnemy);
	}
}