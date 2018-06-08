using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public struct CardStr
	{
		public string Name;
		public string Desc;
		public int Def;
		public int Dmg;
		public int Hp;
		public Sprite Art;

		public enum CardType
		{
			Simple,
			Craft,
			Legendary
		}
	
		//CardType type;

		public CardType CurrentItemType;
	}

	[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
	public class Card : ScriptableObject {

		public Card(string name, string desc, int def, int dmg, int hp, Sprite art, CardType currentType)
		{
			Name = name;
			Desc = desc;
			Def = def;
			Dmg = dmg;
			Hp = hp;
			Art = art;
			CurrentItemType = currentType;
		}
	}
	

	/*public void Print()
	{
		Debug.Log(name + ": " + desc);
	}*/
}

public static class CardList
{
	public static List<Card> AllCards = new List<Card>();
}

public class cardManager : MonoBehaviour
{
	public void Awake()
	{
		CardList.AllCards.Add(new Card());
		CardList.AllCards.Add(new Card());
		CardList.AllCards.Add(new Card());
		CardList.AllCards.Add(new Card());
	}
}