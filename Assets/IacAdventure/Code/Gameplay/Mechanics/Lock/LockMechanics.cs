using System;
using IacAdventure.Gameplay.Interactions;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockMechanics : MonoBehaviour
	{
		#region Inspector

		[SerializeField] public UnityEvent OnCodeSuccess;
		[SerializeField] public UnityEvent OnCodeFail;
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Animation _animation;
		[SerializeField] private AnimationClip _showClip;
		[SerializeField] private AnimationClip _hideClip;
		[SerializeField] private Camera _lockMechanicsCamera;
		[SerializeField] private LayerMask _raycastingLayerMask;
		[SerializeField] private StarterAssetsInputs _inputs;
		[SerializeField] private LockDrum[] _lockDrums;

		#endregion

		#region Fields

		private bool _isWorking;
		private Interacrtable _currentInteractable;
		private string _code;

		#endregion
		
		#region Methods

		public void Show(string code)
		{
			_code = code;
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
			ClearCurrentHighlight();
			var ray = _lockMechanicsCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit, _raycastingLayerMask))
			{
				var interactable = hit.collider.GetComponent<Interacrtable>();
				if (interactable != null)
				{
					SetCurrentHighlight(interactable);
				}

				if (Input.GetMouseButtonDown(0) && _currentInteractable != null)
				{
					_currentInteractable.Interact();
				}
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Hide();
				OnCodeFail?.Invoke();
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

		private void SetCurrentHighlight(Interacrtable  interactable)
		{
			_currentInteractable = interactable;
			_currentInteractable.SetHighlighted();
		}

		public void OnDrumSpinEnd()
		{
			var codeOnLock = string.Format("{0}{1}{2}",
				_lockDrums[0].GetCurrentNumber(),
				_lockDrums[1].GetCurrentNumber(),
				_lockDrums[2].GetCurrentNumber());
			
			if (codeOnLock == _code)
			{
				Hide();
				OnCodeSuccess?.Invoke();
			}
		}

		#endregion
	}
}