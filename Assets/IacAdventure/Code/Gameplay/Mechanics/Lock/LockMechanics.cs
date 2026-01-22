using IacAdventure.Gameplay.Interactions;
using UnityEngine;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockMechanics : MonoBehaviour
	{
		#region Fields

		private Interacrtable _currentInteractable;

		#endregion
		
		#region Methods

		public void Show(string code)
		{
		}

		public void Hide()
		{
		}

		private void Update()
		{
		}

		private void ClearCurrentHighlight()
		{
			if (_currentInteractable != null)
			{
				_currentInteractable.ClearHighlighted();
				_currentInteractable = null;
			}
		}

		private void SetCurrentHighlight(Interacrtable  interactable)
		{
			_currentInteractable = interactable;
			_currentInteractable.SetHighlighted();
		}

		public void OnDrumSpinEnd()
		{
		}

		#endregion
	}
}