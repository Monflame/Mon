using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 offset;
	public Transform DefaultParent, TempCardParent;
	GameObject TempCardGO;
	GameManager gameManager;
	public bool IsDragable;
	public int dragCounter;

	void Awake()
	{
		TempCardGO = GameObject.Find("TempCardGO");
		gameManager = FindObjectOfType<GameManager>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		offset = transform.position - (Vector3)eventData.position; 
		DefaultParent = TempCardParent = transform.parent;
		IsDragable = DefaultParent.GetComponent<CardDrop>().Type == FieldType.hand_self &&
		             gameManager.IsPlayerTurn;
		if(!IsDragable)
			return;
		TempCardGO.transform.SetParent(DefaultParent);
		TempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
		transform.SetParent(DefaultParent.parent); //turn off if change hierarchy
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if(!IsDragable)
			return;

		Vector3 newPos = eventData.position;
		transform.position = newPos + offset;

		if(TempCardGO.transform.parent != TempCardParent)
			TempCardGO.transform.SetParent(TempCardParent);

		dragCounter = DefaultParent.childCount;
		Debug.Log(dragCounter);//
		CheckPosition();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if(!IsDragable)
			return;

		transform.SetParent(DefaultParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		transform.SetSiblingIndex(TempCardGO.transform.GetSiblingIndex());
		TempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
		TempCardGO.transform.localPosition = new Vector3(985,0);
	}

	void CheckPosition()
	{
		int newIndex = TempCardParent.childCount;

		for(int i = 0; i < TempCardParent.childCount; i++)
		{
			if(transform.position.x < TempCardParent.GetChild(i).position.x)
			{
				newIndex = i;
				if(TempCardGO.transform.GetSiblingIndex()<newIndex)
					newIndex--;
				break;
			}
		}

		TempCardGO.transform.SetSiblingIndex(newIndex);
	}
}
