using UnityEngine;
using UnityEngine.Events;

namespace IacAdventure.Gameplay.Interactions
{
	public class Interacrtable : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private UnityEvent _onHighlight;

		[SerializeField]
		private UnityEvent _onClearHighlight;

		[SerializeField]
		private UnityEvent _onInteract;
		
		private bool _isTouched;
		
		#endregion
		
		#region Methods

		public void SetHighlighted()
		{
			if (_isTouched)
			{
				return;
			}
			_isTouched = true;
			_onHighlight.Invoke();
		}

		public void ClearHighlighted()
		{
			if (_isTouched)
			{
				_isTouched = false;
				_onClearHighlight.Invoke();
			}
		}

		public void Interact()
		{
			_onInteract?.Invoke();
		}

		#endregion
	}
}