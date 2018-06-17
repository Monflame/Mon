using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI descText;
	public Image artImage;
	public Image typeFrame;
	public TextMeshProUGUI defText;
	public TextMeshProUGUI dmgText;
	public TextMeshProUGUI hpText;
	public CardObj cardType;

	public void HideCardInfo(CardObj card)
	{
		ShowCardInfo(card);
		//CardSelf = card;
		//artImage.sprite = null;
		//nameText.text = " ";
	}

	public void ShowCardInfo(CardObj card)
	{
		nameText.text = card.name;
		descText.text = card.desc;
		artImage.sprite = card.art;
		cardType.CurrentItemType = card.CurrentItemType;
		typeFrame.sprite = card.type;
		dmgText.text = card.dmg.ToString();
		defText.text = card.def.ToString();
		hpText.text = card.hp.ToString();

#if UNITY_EDITOR
		if(cardType.CurrentItemType == CardObj.CardType.Legendary)
			typeFrame.sprite = Resources.Load<Sprite>("Textures/card_purple");
		else if(cardType.CurrentItemType == CardObj.CardType.Craft)
			typeFrame.sprite = Resources.Load<Sprite>("Textures/card_red");
		else if(cardType.CurrentItemType == CardObj.CardType.Simple)
			typeFrame.sprite = Resources.Load<Sprite>("Textures/card_green");
		else if(cardType.CurrentItemType == CardObj.CardType.Empty__)
			typeFrame.sprite = Resources.Load<Sprite>("Textures/card_empty");
#endif		
	}
}