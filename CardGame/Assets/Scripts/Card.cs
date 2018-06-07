using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {
	public new string name;
	public string desc;
	public int def;
	public int dmg;
	public int hp;
	public Sprite art;

	public enum CardType
	{
		Simple,
		Craft,
		Legendary
	}

	CardType type;

	public CardType currentItemType;

	public void Print()
	{
		Debug.Log(name + ": " + desc);
	}
}

public static class CardList
{
	public static List<Card> AllCards = new List<Card>();
}