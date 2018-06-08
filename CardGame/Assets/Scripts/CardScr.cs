using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public struct Item
{
	public string Title;
	public Sprite Logo;
	public int Attack;
	public int Health;

	public Item(string title, string logoPath, int attack, int health)
	{
		Title = title;
		Logo = Resources.Load<Sprite>(logoPath);
		Attack = attack;
		Health = health;
	}

}

public static class ItemManager
{
	public static List<Item> ItemsList = new List<Item>();
}

public class CardScr : MonoBehaviour
{
	public void Awake()
	{
		ItemManager.ItemsList.Add(new Item("Cthulhu", "Textures/cthulhu", 10, 10));
		ItemManager.ItemsList.Add(new Item("Alien", "Textures/alien", 7, 5));
		ItemManager.ItemsList.Add(new Item("Mummy", "Textures/mummy", 5, 10));
		ItemManager.ItemsList.Add(new Item("Beholder", "Textures/beholder", 9, 3));
		ItemManager.ItemsList.Add(new Item("Ghosts", "Textures/ghosts", 2, 12));
	}

}
