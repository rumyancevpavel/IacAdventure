using IacAdventure.Gameplay.Interactions;
using IacAdventure.Gameplay.Inventory;
using IacAdventure.Gameplay.Tools;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureChestWood : MonoBehaviour
	{
		[SerializeField] private bool _isLocked;
		[SerializeField] private InventoryItemType _lockedBy;
		[SerializeField] private InventoryItemType _itemToGive;
		[SerializeField] private Animation _openAnimation;
		[SerializeField] private float _flySpeed = 15;
		
		private bool _isOpen;
		
		public void Interact()
		{
			if (_isOpen)
			{
				return;
			}

			if (_isLocked)
			{
				if (GameInventory.Instance.HasItem(_lockedBy))
				{
					_openAnimation.Play();
					_isOpen = true;
					if (_itemToGive != InventoryItemType.Undefined)
					{
						var item3d = InventoryItemsCatalog.Instance.CreateItemPrefab(_itemToGive, transform.position, Quaternion.identity);
						if (item3d != null)
						{
							StartCoroutine(A2bHelper.FlyToTargetCoroutine(item3d, InventoryItemCollectionTarget.Instance.Target, _flySpeed));
						}

						GameInventory.Instance.PutItem(_itemToGive);
					}
					GameInventory.Instance.UseItem(_lockedBy);
				}
				else
				{
					Debug.Log($"The chest is locked. You need {_lockedBy} to open it");
				}
			}
		}
	}
}