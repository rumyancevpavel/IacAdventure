using System.Collections;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Events;

namespace IacAdventure.Gameplay.Mechanics.Lock
{
	public class LockDrum : MonoBehaviour
	{
		#region Consts

		private const float SINGLE_NUMBER_ROTATION = 360 / 8;

		#endregion
		
		#region Methods

		private void Start()
		{
		}

		public void SpinToNextNumber()
		{
		}
		
		public int GetCurrentNumber()
		{
			return Mathf.RoundToInt(transform.rotation.eulerAngles.z / SINGLE_NUMBER_ROTATION) + 1;
		}

		#endregion
	}
}