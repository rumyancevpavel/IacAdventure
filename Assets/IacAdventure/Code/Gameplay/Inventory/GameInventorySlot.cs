using UnityEngine;
using UnityEngine.UI;

namespace IacAdventure.Gameplay.Inventory
{
	public class GameInventorySlot : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Image _focusFrameImage;

		[SerializeField] private Image _itemImage;

		#endregion

		public InventoryItemType ItemType
		{
			get { return _itemType; }
		}
		
		#region Fields

		private InventoryItemType _itemType = InventoryItemType.Undefined;
		
		#endregion

		#region Method

		public void PutItem(InventoryItemType itemType)
		{
			if (HasItem())
			{
				Debug.Log("Can't put item into slot. Slot is already taken");
				return;
			}

			_itemType = itemType;
			var itemInfo = InventoryItemsCatalog.Instance.GetItemInfo(itemType);
			_itemImage.sprite = itemInfo.Icon;
			_itemImage.enabled = true;
		}

		public void Use()
		{
			_itemType = InventoryItemType.Undefined;
			_itemImage.sprite = null;
			_itemImage.enabled = false;
		}

		public bool HasItem()
		{
			return _itemType != InventoryItemType.Undefined;
		}

		public bool IsEmpty()
		{
			return !HasItem();
		}

		#endregion
	}
}