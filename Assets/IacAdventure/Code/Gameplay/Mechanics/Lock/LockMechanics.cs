using System;
using IacAdventure.Gameplay.Interactions;
using StarterAssets;
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
		[SerializeField] private StarterAssetsInputs _inputs;

		#endregion

		#region Fields

		private bool _isWorking;
		private Interacrtable _currentInteractable;

		
		#endregion
		
		#region Methods

		public void Show()
		{
			_playerInput.DeactivateInput();
			_animation.Stop();
			_animation.clip = _showClip;
			_animation.Play();
			_inputs.cursorLocked = false;
			Cursor.lockState = CursorLockMode.None;
			_isWorking = true;
		}

		public void Hide()
		{
			_playerInput.ActivateInput();
			_animation.Stop();
			_animation.clip = _hideClip;
			_animation.Play();
			_inputs.cursorLocked = true;
			Cursor.lockState = CursorLockMode.Locked;
			_isWorking = false;
		}

		private void Update()
		{
			if (!_isWorking)
			{
				return;
			}
			var ray = _lockMechanicsCamera.ScreenPointToRay(Input.mousePosition);
			ClearCurrentHighlight();
			if (Physics.Raycast(ray, out RaycastHit hit, _raycastingLayerMask))
			{
				var interactable = hit.collider.GetComponent<Interacrtable>();
				if (interactable != null)
				{
					_currentInteractable = interactable;
					_currentInteractable.SetHighlighted();
				}
			}
		}

		private void ClearCurrentHighlight()
		{
			if (_currentInteractable != null)
			{
				_currentInteractable.ClearHighlighted();
				_currentInteractable = null;
			}
		}

		#endregion
	}
}