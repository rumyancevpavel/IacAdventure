using UnityEngine;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockedByLock : MonoBehaviour
	{
		#region Inspector

		[SerializeField] private string _code = "111";
		[SerializeField] private LockMechanics _lockMechanics;
		
		#endregion
	}
}