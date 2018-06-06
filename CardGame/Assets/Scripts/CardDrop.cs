using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnDrop(PointerEventData eventData)
	{
		CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();
		if(card)
			card.DefaultParent = transform;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null)
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
