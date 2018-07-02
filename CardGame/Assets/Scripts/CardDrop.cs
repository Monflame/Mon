﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
	hand_self,
	hand_enemy,
	field_self,
	field_enemy
}

public class CardDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public FieldType Type;
	GameManager gameManager;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	public void OnDrop(PointerEventData eventData)
	{
		if(!gameManager.IsEnemyTurn)
		{
			if(Type != FieldType.field_self)
				return;
		}

		if(!gameManager.IsPlayerTurn)
		{
			if(Type != FieldType.field_enemy)
				return;
		}

		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();

		if(card)
		{
			card.DefaultParent = transform;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(!gameManager.IsEnemyTurn)
		{
			if(eventData.pointerDrag == null || Type == FieldType.field_enemy ||
			   Type == FieldType.hand_enemy)
				return;
		}
		else
		{
			if(eventData.pointerDrag == null || Type == FieldType.field_self ||
			   Type == FieldType.hand_self)
				return;
		}

		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();

		if(card)
			card.TempCardParent = transform;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if(!gameManager.IsEnemyTurn)
		{
			if (eventData.pointerDrag == null || Type != FieldType.hand_self)
				return;
		}
		else
		{
			if (eventData.pointerDrag == null || Type != FieldType.hand_enemy)
				return;
		}

		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();

		if(card && card.TempCardParent == transform)
			card.TempCardParent = card.DefaultParent;
	}
}