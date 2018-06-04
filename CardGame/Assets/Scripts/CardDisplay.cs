using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card card;
	public Text nameText;
	public Text descText;
	public Image artImage;
	public Text defText;
	public Text dmgText;
	public Text hpText;

	void Start()
	{
		card.Print();
		nameText.text = card.name;
		descText.text = card.desc;
		artImage.sprite = card.art;
		dmgText.text = card.dmg.ToString();
		defText.text = card.def.ToString();
		hpText.text = card.hp.ToString();
	}
}
