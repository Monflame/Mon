using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CardList
{
	public static List<CardObj> AllCards = new List<CardObj>();
}

public class CardNode : MonoBehaviour {

	void Awake(){
		/*CardList.AllCards.Add(new CardObj("Lovecraft", "Howard Philips", 1, 1, 1, Resources.Load<Sprite>("Textures/lovecraft")));
		CardList.AllCards.Add(new CardObj("Cthulhu", "The Great One!", 10, 10, 10, Resources.Load<Sprite>("Textures/cthulhu")));
		CardList.AllCards.Add(new CardObj("Beholder", "Always watching you", 5, 8, 3, Resources.Load<Sprite>("Textures/beholder")));
		CardList.AllCards.Add(new CardObj("Ghosts", "Beyond the death and life", 12, 3, 10, Resources.Load<Sprite>("Textures/ghosts")));
		CardList.AllCards.Add(new CardObj("Alien", "From the outer space", 3, 10, 5, Resources.Load<Sprite>("Textures/alien")));
		CardList.AllCards.Add(new CardObj("Mummy", "Rised from its tomb", 5, 5, 12, Resources.Load<Sprite>("Textures/mummy")));*/
		//CardObj cardObj = ScriptableObject.CreateInstance("CardObj") as CardObj;
		CardObj data = CardObj.CreateInstance("Cthulhu", "The Great One!", 10, 10, 10, Resources.Load<Sprite>("Textures/cthulhu"));
	}

	void Start()
	{
		CardList.AllCards.Add(new CardObj());
	}
}