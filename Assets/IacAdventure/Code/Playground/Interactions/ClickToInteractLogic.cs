using IacAdventure.Gameplay.Interactions;
using UnityEngine;

namespace IacAdventure.Playground.Interactions
{
	[RequireComponent(typeof(Camera))]
	public class ClickToInteractLogic : MonoBehaviour
	{
		[SerializeField] private Camera _raycastCamera;
		[SerializeField] private float _raycastDistance = 15;
		[SerializeField] private LayerMask _raycastLayerMask;
		
		private Interacrtable _currentInteractable;
		
		private void Awake()
		{
			_raycastCamera = GetComponent<Camera>();
		}

		private void Update()
		{
			DetectInteraction();
			DetectClickOnInteractable();
		}
		
		private void DetectInteraction()
		{
			var ray = _raycastCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _raycastLayerMask))
			{
				TryHighlightInteractable(hit.collider);
			}
			else
			{
				ClearCurrentInteractable();
			}
		}

		private void DetectClickOnInteractable()
		{
			if (Input.GetMouseButtonDown(0) && _currentInteractable != null)
			{
				_currentInteractable.Interact();
			}
		}

		private void TryHighlightInteractable(Collider hitCollider)
		{
			if (hitCollider.TryGetComponent(out _currentInteractable))
			{
				_currentInteractable.SetHighlighted();
			}
		}

		private void ClearCurrentInteractable()
		{
			if (_currentInteractable != null)
			{
				_currentInteractable.ClearHighlighted();
				_currentInteractable = null;
			}
		}
	}
}