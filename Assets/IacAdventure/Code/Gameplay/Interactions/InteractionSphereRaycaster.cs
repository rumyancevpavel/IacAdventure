using UnityEngine;

namespace IacAdventure.Gameplay.Interactions
{
	public class InteractionSphereRaycaster : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField]
		private Transform _raycastOrigin;
		
		[SerializeField]
		private float _raycastRadius;
		
		[SerializeField]
		private float _raycastDistance;
		
		[SerializeField
		]
		private LayerMask _raycastLayerMask;
		
		#endregion

		#region Fields

		private InteractionRaycastReceiver _currentReceiver;

		private Collider _lastCollider;
		
		#endregion
		
		#region Methods

		private void Update()
		{
			Logic();
		}

		private void Logic()
		{
			if (Physics.SphereCast(_raycastOrigin.position, _raycastRadius, _raycastOrigin.forward,
				    out var hit, _raycastDistance, _raycastLayerMask))
			{
				if (hit.collider == _lastCollider)
				{
					return;
				}

				SetCurrentReceiver(hit.collider);
			}
			else
			{
				ClearCurrentReceiver();
			}
		}

		private void SetCurrentReceiver(Collider collider)
		{
			_lastCollider = collider;
			_currentReceiver = _lastCollider.GetComponent<InteractionRaycastReceiver>();
			if (_currentReceiver != null)
			{
				_currentReceiver.SetTouched();
			}
		}

		private void ClearCurrentReceiver()
		{
			if (_currentReceiver != null)
			{
				_currentReceiver.ClearTouched();
				_currentReceiver = null;
				_lastCollider = null;
			}
		}

		#endregion
	}
}