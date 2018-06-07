using System.Collections;
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

	public void OnDrop(PointerEventData eventData)
	{
		if(Type != FieldType.field_self)
			return;
			
		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();
		if(card)
			card.DefaultParent = transform;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null || Type == FieldType.field_enemy || Type == FieldType.hand_enemy)
			return;
		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();

		if(card)
			card.TempCardParent = transform;
	}

		public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag==null)
			return;
		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();

		if(card && card.TempCardParent == transform)
			card.TempCardParent = card.DefaultParent;

	}
}
