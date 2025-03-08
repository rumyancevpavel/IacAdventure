using UnityEngine;

namespace IacAdventure.Gameplay.Inventory
{
	public class GameInventory : MonoBehaviour
	{
		#region Singleton

		private static GameInventory _instance;

		public static GameInventory Instance
		{
			get
			{
				return _instance;
			}
		}

		#endregion

		#region Editor Exposed

		[SerializeField] private GameInventorySlot[] _slots;

		#endregion
		
		#region Methods

		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(gameObject);
				Debug.LogError("Detected attempt to duplicate instantiation of [GameInventory]");
				return;
			}
			_instance = this;
		}

		public void PutItem(InventoryItemType itemType)
		{
			if (HasEmptySlot())
			{
				var slot = GetEmptySlot();
				slot.PutItem(itemType);
			}
		}

		public bool HasItem(InventoryItemType itemType)
		{
			foreach (var slot in _slots)
			{
				if (slot.ItemType == itemType)
				{
					return true;
				}
			}

			return false;
		}

		public void UseItem(InventoryItemType itemType)
		{
			var slot = GetSlotByItem(itemType);
			if (slot != null)
			{
				slot.Use();
			}
		}

		private bool HasEmptySlot()
		{
			foreach (var slot in _slots)
			{
				if (slot.IsEmpty())
				{
					return true;
				}
			}
			return false;
		}

		private GameInventorySlot GetEmptySlot()
		{
			foreach (var slot in _slots)
			{
				if (slot.IsEmpty())
				{
					return slot;
				}
			}

			return null;
		}

		private GameInventorySlot GetSlotByItem(InventoryItemType itemType)
		{
			foreach (var slot in _slots)
			{
				if (slot.ItemType == itemType)
				{
					return slot;
				}
			}

			return null;
		}
		
		#endregion
	}
}