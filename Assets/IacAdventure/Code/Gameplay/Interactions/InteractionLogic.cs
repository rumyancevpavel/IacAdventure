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

		#endregion
		
		#region Methods

		private void Awake()
		{
		}

		private void Update()
		{
			DetectInteraction();
		}

		private void DetectInteraction()
		{
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

		#endregion
	}
}