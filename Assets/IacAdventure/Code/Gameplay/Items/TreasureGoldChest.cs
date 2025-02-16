using System.Collections;
using System.Collections.Generic;
using IacAdventure.Gameplay.Inventory;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class TreasureGoldChest : MonoBehaviour
	{
		#region Editor Exposed
		
		[SerializeField]
		private int _experiencePoints;

		[SerializeField]
		private int _goldAmount;

		[SerializeField]
		private int _gemsAmount;

		[SerializeField]
		private Animation _openLidAnimation;
		
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
			Debug.Log($"[TreasureGoldChest] Collect(), Gold={_goldAmount}, Gems={_gemsAmount}, Experience={_experiencePoints}");
			_isCollected = true;
			StartCoroutine(CollectCoroutine());
		}

		private IEnumerator CollectCoroutine()
		{
			GameInventory.AddExperience(_experiencePoints);
			GameInventory.AddGold(_goldAmount);
			GameInventory.AddGems(_gemsAmount);
			_openLidAnimation.Play();
			yield return new WaitForSeconds(_openLidAnimation.clip.length);
		}

		#endregion
	}
}