using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public Card CardSelf;
	public Text nameText;
	public Text descText;
	public Image artImage;
	public Text defText;
	public Text dmgText;
	public Text hpText;

	public void HideCardInfo(Card card)
	{
		CardSelf = card;
		artImage.sprite = null;
		nameText.text = " ";
	}

	public void ShowCardInfo(Card.CardStr card)
	{
		//card.Print();
		CardSelf = card;
		nameText.text = card.name;
		descText.text = card.desc;
		artImage.sprite = card.art;
		dmgText.text = card.dmg.ToString();
		defText.text = card.def.ToString();
		hpText.text = card.hp.ToString();
	}

	private void Start()
	{
		ShowCardInfo(CardList.AllCards[transform.GetSiblingIndex()]);
	}
}