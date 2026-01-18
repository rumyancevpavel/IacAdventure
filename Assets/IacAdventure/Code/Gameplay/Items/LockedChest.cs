using IacAdventure.Gameplay.Mechanics.Lock;
using UnityEngine;

namespace IacAdventure.Gameplay.Items
{
	public class LockedChest : MonoBehaviour
	{
		#region Inspector

		[SerializeField] private string _code = "111";
		[SerializeField] private LockMechanics _lockMechanics;
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
			_lockMechanics.Show();
		}

		#endregion
	}
}