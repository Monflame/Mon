using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public struct Item
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

	CardType Type;
	public CardType CurrentItemType;

	public Item(string name, string desc, int def, int dmg, int hp, Sprite art, CardType type, CardType itemType)
	{
		Name = name;
		Desc = desc;
		Art = art;
		Def = def;
		Dmg = dmg;
		Hp = hp;
		Type = type;
		CurrentItemType = itemType;
	}
}

/*public static class CardList
{
	public static List<Item> AllCards = new List<Item>();
}*/

public class CardStruct : MonoBehaviour {

	void Start ()
	{
		
	}
}
