using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
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
	public Sprite type;

	public enum CardType
	{
		Simple,
		Craft,
		Legendary,
		Empty__
	}

	public CardType CurrentItemType;
}