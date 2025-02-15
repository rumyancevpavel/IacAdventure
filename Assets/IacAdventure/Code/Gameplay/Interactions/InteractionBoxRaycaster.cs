using UnityEngine;
using UnityEngine.Serialization;

namespace IacAdventure.Gameplay.Interactions
{
	public class InteractionBoxRaycaster : MonoBehaviour
	{
		#region Editor Exposed

		[SerializeField] private Transform _raycastCube;
		
		[SerializeField] private Mesh _raycastCubeMesh;
		
		[SerializeField] private Vector3 _raycastHalfExtents = Vector3.one;
		
		[SerializeField] private float _raycastDistance;
		
		[SerializeField] private LayerMask _raycastLayerMask;
		
		#endregion

		#region Fields

		private InteractionRaycastReceiver _currentReceiver;

		private bool _isHitDetected;

		private RaycastHit _lastHit;
		
		#endregion
		
		#region Methods

		private void FixedUpdate()
		{
			Logic2();
		}

		private void Logic2()
		{
			var overlaps = Physics.OverlapBox(_raycastCube.position, _raycastCube.localScale, _raycastCube.rotation, _raycastLayerMask);
			if (overlaps == null || overlaps.Length == 0)
			{
				ClearCurrentReceiver();
			}
			else
			{
				var firstOverlap = overlaps[0];
				SetCurrentReceiver(firstOverlap);
			}
		}

		private void SetCurrentReceiver(Collider collider)
		{
			_currentReceiver = collider.GetComponent<InteractionRaycastReceiver>();
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