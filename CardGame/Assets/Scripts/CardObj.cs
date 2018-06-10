using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardObj : ScriptableObject {

	public CardObj CardSelf;
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

	CardType Type;

	public CardType CurrentItemType;

	public void Init(string name, string desc, int def, int dmg, int hp, Sprite art)
	{
		this.name = name;
		this.desc = desc;
		this.def = def;
		this.dmg = dmg;
		this.hp = hp;
		this.art = art;
	}

	public static CardObj CreateInstance(string name, string desc, int def, int dmg, int hp, Sprite art)
	{
		var data = ScriptableObject.CreateInstance<CardObj>();
		data.Init(name, desc, def, dmg, hp, art);
		return data;
	}

	/*public CardObj(CardObj card)
	{
		CardSelf = card;
	}*/
}