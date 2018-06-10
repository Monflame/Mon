using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour {

	public CardObj CardSelf;
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI descText;
	public Image artImage;
	public TextMeshProUGUI defText;
	public TextMeshProUGUI dmgText;
	public TextMeshProUGUI hpText;

	public void HideCardInfo(CardObj card)
	{
		ShowCardInfo(card);
		//CardSelf = card;
		//artImage.sprite = null;
		//nameText.text = " ";
	}

	public void ShowCardInfo(CardObj card)
	{
		CardSelf = card;
		nameText.text = card.name;
		descText.text = card.desc;
		artImage.sprite = card.art;
		dmgText.text = card.dmg.ToString();
		defText.text = card.def.ToString();
		hpText.text = card.hp.ToString();
	}
}