using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockMechanics : MonoBehaviour
	{
		#region Inspector

		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Animation _animation;
		[SerializeField] private AnimationClip _showClip;
		[SerializeField] private AnimationClip _hideClip;
		[SerializeField] private Camera _lockMechanicsCamera;
		[SerializeField] private LayerMask _raycastingLayerMask;

		#endregion

		#region Fields

		private bool _isWorking;

		#endregion
		
		#region Methods

		public void Show()
		{
			_playerInput.DeactivateInput();
			_animation.Stop();
			_animation.clip = _showClip;
			_animation.Play();
			Cursor.lockState = CursorLockMode.None;
			_isWorking = true;
		}

		public void Hide()
		{
			_playerInput.ActivateInput();
			_animation.Stop();
			_animation.clip = _hideClip;
			_animation.Play();
			Cursor.lockState = CursorLockMode.Locked;
			_isWorking = false;
		}

		private void Update()
		{
			if (!_isWorking)
			{
				return;
			}
			
		}

		#endregion
	}
}