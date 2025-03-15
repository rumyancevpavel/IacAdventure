using IacAdventure.Gameplay.Interactions;
using IacAdventure.Gameplay.Inventory;
using IacAdventure.Gameplay.Tools;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureGoldChest : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Animation _animation;
		[SerializeField] private InventoryItemType _inventoryItemType;
		[SerializeField] private float _flySpeed = 15;
		
		#endregion
		
		#region Fields

		private bool _isCollected;

		#endregion
		
		#region Methods

		public void Collect()
		{
			if (_isCollected)
			{
				return;
			}

			_animation.Play();
			if (_inventoryItemType != InventoryItemType.Undefined)
			{
				var item3d = InventoryItemsCatalog.Instance.CreateItemPrefab(_inventoryItemType, transform.position, Quaternion.identity);
				if (item3d != null)
				{
					StartCoroutine(A2bHelper.FlyToTargetCoroutine(item3d, InventoryItemCollectionTarget.Instance.Target, _flySpeed));
				}
				
				GameInventory.Instance.PutItem(_inventoryItemType);
			}
		}
		
		#endregion
	}
}