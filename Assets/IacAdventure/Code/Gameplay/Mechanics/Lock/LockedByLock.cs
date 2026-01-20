using UnityEngine;
using UnityEngine.Events;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockedByLock : MonoBehaviour
	{
		#region Inspector

		[SerializeField] private string _code = "111";
		[SerializeField] private LockMechanics _lockMechanics;
		[SerializeField] private UnityEvent Unlocked;

		#endregion

		#region Fields

		private bool _isUnlocked;

		#endregion
		
		#region Methods

		public void TryUnlock()
		{
			if (_isUnlocked)
			{
				Unlocked?.Invoke();
				return;
			}
			_lockMechanics.OnCodeSuccess.RemoveAllListeners();
			_lockMechanics.OnCodeSuccess.AddListener(OnCodeSuccess);
			_lockMechanics.Show(_code);
		}

		private void OnCodeSuccess()
		{
			_isUnlocked = true;
			Unlocked?.Invoke();
		}

		#endregion
	}
}