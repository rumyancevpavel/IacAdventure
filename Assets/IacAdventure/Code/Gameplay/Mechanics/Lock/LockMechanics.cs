using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockMechanics : MonoBehaviour
	{
		#region Inspector

		[SerializeField] private PlayerInput _playerInput;

		#endregion

		#region Methods

		public void Show()
		{
			_playerInput.DeactivateInput();
		}

		public void Hide()
		{
			_playerInput.ActivateInput();
		}

		#endregion
	}
}