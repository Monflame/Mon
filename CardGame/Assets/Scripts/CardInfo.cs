using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour {

	public Item SelfCard;
	public Image Logo;
	public TextMeshProUGUI Title;

	public void HideItemInfo(Item card)
	{
		//SelfCard = card;
		ShowItemInfo(card);
		//Logo.sprite = null;
		//Title.text = " ";
	}
	
	public void ShowItemInfo(Item card)
	{
		SelfCard = card;
		Title.text = card.Title;
		Logo.sprite = card.Logo;
		Logo.preserveAspect = true;
	}

	private void Start()
	{
		//ShowItemInfo(ItemManager.ItemsList[transform.GetSiblingIndex()]);
	}
}
