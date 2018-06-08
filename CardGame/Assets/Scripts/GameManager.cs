using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPull
{
	public List<Item> DeckSelf, DeckEnemy,
						HandSelf, HandEnemy,
						Fieldself, FieldEnemy;

	public CardPull()
	{
		DeckSelf = GetDeckCards();
		DeckEnemy = GetDeckCards();
		HandSelf = new List<Item>();
		HandEnemy = new List<Item>();
		Fieldself = new List<Item>();
		FieldEnemy = new List<Item>();
	}

	List<Item> GetDeckCards()
	{
		List<Item> list = new List<Item>();
		for(int i = 0; i < 10; i++)
			list.Add(ItemManager.ItemsList[Random.Range(0,ItemManager.ItemsList.Count)]);	
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
	void GetHandCards(List<Item> deck, Transform hand)
	{
		int i = 0;
		while(i++ <4)
			GetCardToHand(deck, hand);
	}

	void GetCardToHand(List<Item> deck, Transform hand)
	{
		if(deck.Count == 0)
			return;

		Item card = deck[0];

		GameObject cardGO = Instantiate(CardPref, hand, false);

		if(hand == HandEnemy)
			cardGO.GetComponent<CardInfo>().HideItemInfo(card);
		else
			cardGO.GetComponent<CardInfo>().ShowItemInfo(card);

		deck.RemoveAt(0);
	}
}
