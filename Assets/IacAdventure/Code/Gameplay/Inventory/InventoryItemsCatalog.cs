using System.Collections.Generic;
using UnityEngine;

namespace IacAdventure.Gameplay.Inventory
{
	public class InventoryItemsCatalog : MonoBehaviour
	{
		#region Singleton

		private static InventoryItemsCatalog _instance;

		public static InventoryItemsCatalog Instance
		{
			get
			{
				return _instance;
			}
		}

		#endregion
		
		#region Editor Exposed

		[SerializeField] private List<InventoryItemInfo> _inventoryItems;
		
		#endregion
		
		#region Methods

		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(gameObject);
				Debug.LogError("Detected attempt to duplicate instantiation of [InventoryItemsCatalog]");
				return;
			}
			_instance = this;
		}

		#endregion

		#region Methods

		public InventoryItemInfo GetItemInfo(InventoryItemType itemType)
		{
			InventoryItemInfo result = null;
			for (var i = 0; i < _inventoryItems.Count; i++)
			{
				if (_inventoryItems[i].Type == itemType)
				{
					result = _inventoryItems[i];
				}
			}

			return result;
		}

		#endregion
	}
}