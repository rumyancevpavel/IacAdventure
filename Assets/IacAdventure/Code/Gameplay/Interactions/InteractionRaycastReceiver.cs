using UnityEngine;
using UnityEngine.Events;

namespace IacAdventure.Gameplay.Interactions
{
	public class InteractionRaycastReceiver : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private UnityEvent _onTouched;

		[SerializeField]
		private UnityEvent _onTouchReleased;
		
		private bool _isTouched;
		
		#endregion
		
		#region Methods

		public void SetTouched()
		{
			if (_isTouched)
			{
				return;
			}
			_isTouched = true;
			_onTouched.Invoke();
		}

		public void ClearTouched()
		{
			if (_isTouched)
			{
				_isTouched = false;
				_onTouchReleased.Invoke();
			}
		}

		#endregion
	}
}