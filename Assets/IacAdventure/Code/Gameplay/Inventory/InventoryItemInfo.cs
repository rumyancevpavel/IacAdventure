using System;
using UnityEngine;

namespace IacAdventure.Gameplay.Inventory
{
	[Serializable]
	public class InventoryItemInfo
	{
		public InventoryItemType Type;
		public Sprite Icon;
		public GameObject Prefab;
	}
}