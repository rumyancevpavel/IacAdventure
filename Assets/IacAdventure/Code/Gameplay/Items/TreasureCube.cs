using IacAdventure.Gameplay.Inventory;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureCube : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField]
		private int _experiencePoints;

		[SerializeField]
		private int _goldAmount;

		[SerializeField]
		private int _gemsAmount;

		#endregion

		#region Methods

		public void PutIntoInventory()
		{
			Debug.Log($"[TreasureCube] PutIntoInventory(). Gold={_goldAmount}, Gems={_gemsAmount}, Experience={_experiencePoints}");
			GameInventory.AddGold(_goldAmount);
			GameInventory.AddExperience(_experiencePoints);
			GameInventory.AddGems(_gemsAmount);
		}

		#endregion
	}
}