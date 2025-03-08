using IacAdventure.Gameplay.Inventory;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureGoldChest : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Animation _animation;
		
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
		}
		
		#endregion
	}
}