using StarterAssets;
using UnityEngine;

namespace IacAdventure.Gameplay.Interactions
{
	public class InteractionLogic : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Transform _raycastCube;
		
		[SerializeField] private Mesh _raycastCubeMesh;
		
		[SerializeField] private LayerMask _raycastLayerMask;

		[SerializeField] private ThirdPersonController _characterController;
		
		#endregion

		#region Fields

		private Interacrtable _currentInteractable;

		private bool _isHitDetected;

		private RaycastHit _lastHit;
		
		#endregion
		
		#region Methods

		private void Awake()
		{
			_characterController.InteractionRequested.AddListener(OnInteractionRequested);
		}

		private void OnInteractionRequested()
		{
			if (_currentInteractable == null)
			{
				return;
			}
			_currentInteractable.Interact();
		}

		private void Update()
		{
			DetectInteraction();
		}

		private void DetectInteraction()
		{
			var overlaps = Physics.OverlapBox(_raycastCube.position, _raycastCube.localScale * 0.5f, _raycastCube.rotation, _raycastLayerMask);
			if (overlaps == null || overlaps.Length == 0)
			{
				ClearCurrentHighlight();
			}
			else
			{
				var firstOverlap = overlaps[0];
				SetCurrentHighlight(firstOverlap);
			}
		}

		private void SetCurrentHighlight(Collider collider)
		{
			_currentInteractable = collider.GetComponent<Interacrtable>();
			if (_currentInteractable != null)
			{
				_currentInteractable.SetHighlighted();
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

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireMesh(_raycastCubeMesh, _raycastCube.position, _raycastCube.rotation, _raycastCube.localScale);
#endif
		}

		#endregion
	}
}