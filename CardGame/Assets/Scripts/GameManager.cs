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

	List<CardObj> GetDeckCards()
	{
		List<CardObj> list = new List<CardObj>();
		for(int i = 0; i < 10; i++)
			list.Add(CardList.AllCards[Random.Range(0,CardList.AllCards.Count)]);	
		return list;
	}
}

public class GameManager : MonoBehaviour {

	public CardPull CurrentPull;
	public Transform HandSelf, HandEnemy;
	public int counterSelf, counterEnemy;//
	public GameObject CardPref;
	int Turn, TurnTime = 30;
	public TextMeshProUGUI TurnTimeText;
	public Button EndTurnBtn;
	public int counter;

	public bool IsPlayerTurn
	{
		get
		{
			return Turn % 2 == 0;
		}
	}

	void Start()
	{
		Turn = 0;
		CurrentPull = new CardPull();

		GetHandCards(CurrentPull.DeckEnemy, HandEnemy);
		GetHandCards(CurrentPull.DeckSelf, HandSelf);
		StartCoroutine(TurnFunc());
	}

	void GetHandCards(List<CardObj> deck, Transform hand)
	{
		int i = 0;
		while(i++ <5)
			GetCardToHand(deck, hand);
			counter = i;
			//Debug.Log("Counter: " + counter);
	}

	void GetCardToHand(List<CardObj> deck, Transform hand)
	{
		if(deck.Count == 0)
			return;

		CardObj card = deck[0];

		GameObject cardGO = Instantiate(CardPref, hand, false);

		if(hand == HandEnemy)
			cardGO.GetComponent<CardDisplay>().HideCardInfo(card);
		else
			cardGO.GetComponent<CardDisplay>().ShowCardInfo(card);

		deck.RemoveAt(0);
	}

	IEnumerator TurnFunc()
	{
		TurnTime = 26;
		TurnTimeText.text = TurnTime.ToString();

		if(IsPlayerTurn)
		{
			while(TurnTime-- > 0 && counter > 1)
			{
				TurnTimeText.text = TurnTime.ToString();
				yield return new WaitForSeconds(1);
			}
		}
		else
		{
			while(TurnTime-- > 22)
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
		GetCardToHand(CurrentPull.DeckSelf, HandSelf);
		counter++;
		//Debug.Log("Counter: " + counter);
	}
}
