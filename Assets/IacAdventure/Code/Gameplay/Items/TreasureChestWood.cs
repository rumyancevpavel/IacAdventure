using IacAdventure.Gameplay.Inventory;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureChestWood : MonoBehaviour
	{
		[SerializeField] private bool _isLocked;
		[SerializeField] private Animation _openAnimation;
		
		private bool _isOpen;
		
		public void Interact()
		{
		}
	}
}