using UnityEngine;

namespace IacAdventure.Gameplay.Interactions
{
	public class InteractionRaycastReceiver : MonoBehaviour
	{
		#region Fields

		private bool _touchedByRay;

		#endregion
		
		#region Methods

		public void SetTouched()
		{
			Debug.Log($"{gameObject.name} SetTouched");
		}

		public void ClearTouched()
		{
			Debug.Log($"{gameObject.name} ClearTouched");
		}

		#endregion
	}
}