using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 offset;
	public Transform DefaultParent, TempCardParent;
	GameObject TempCardGO;

	void Awake()
	{
		TempCardGO = GameObject.Find("TempCardGO");
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		offset = transform.position - (Vector3)eventData.position; 
		DefaultParent = TempCardParent = transform.parent;
		TempCardGO.transform.SetParent(DefaultParent);
		TempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
		transform.SetParent(DefaultParent.parent); //turn off if change hierarchy
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 newPos = eventData.position;
		transform.position = newPos + offset;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(DefaultParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		TempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
		TempCardGO.transform.localPosition = new Vector3(890,0);
	}
}
