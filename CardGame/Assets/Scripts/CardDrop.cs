﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrop : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData)
	{
		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();
		if(card)
			card.DefaultParent = transform;
	}
}
