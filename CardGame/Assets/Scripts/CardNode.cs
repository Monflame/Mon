using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CardList
{
	public static List<CardObj> AllCards = new List<CardObj>();
}

public class CardNode : MonoBehaviour {
	private static CardObj cthulhu, ghosts, mummy, beholder, alien, lovecraft;
	public void Awake()
	{
		cthulhu = Resources.Load<CardObj>("Cards/Cthulhu");
		ghosts = Resources.Load<CardObj>("Cards/Ghosts");
		mummy = Resources.Load<CardObj>("Cards/Mummy");
		beholder = Resources.Load<CardObj>("Cards/Beholder");
		alien = Resources.Load<CardObj>("Cards/Alien");
		lovecraft = Resources.Load<CardObj>("Cards/Lovecraft");
		CardList.AllCards.Add(cthulhu);
		CardList.AllCards.Add(ghosts);
		CardList.AllCards.Add(mummy);
		CardList.AllCards.Add(beholder);
		CardList.AllCards.Add(alien);
		CardList.AllCards.Add(lovecraft);
	}
}