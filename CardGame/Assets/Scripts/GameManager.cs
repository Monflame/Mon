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
	public GameObject CardPref;

	void Start()
	{
		CurrentPull = new CardPull();

		GetHandCards(CurrentPull.DeckEnemy, HandEnemy);
		GetHandCards(CurrentPull.DeckSelf, HandSelf);
	}
	void GetHandCards(List<CardObj> deck, Transform hand)
	{
		int i = 0;
		while(i++ <5)
			GetCardToHand(deck, hand);
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
}
