using IacAdventure.Gameplay.Interactions;
using IacAdventure.Gameplay.Inventory;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureGoldChest : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Animation _animation;
		
		[SerializeField] private InventoryItemType _inventoryItemType;
		
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
				GameInventory.Instance.PutItem(_inventoryItemType);
			}
		}
		
		#endregion
	}
}