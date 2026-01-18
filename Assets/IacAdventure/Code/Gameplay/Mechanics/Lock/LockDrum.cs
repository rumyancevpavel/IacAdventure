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
		
		#region Inspector

		[SerializeField] private UnityEvent OnDrumSpinEnd;

		#endregion

		#region Methods

		private void Start()
		{
			SetRandomNumber();
		}

		private void SetRandomNumber()
		{
			var randomNumber = Random.Range(0, 8);
			var angle = SINGLE_NUMBER_ROTATION * randomNumber;
			transform.Rotate(0,0,angle);
		}

		public void SpinToNextNumber()
		{
			StartCoroutine(SpinCoroutine());
		}

		private IEnumerator SpinCoroutine()
		{
			for (var i = 1; i <= SINGLE_NUMBER_ROTATION; i++)
			{
				transform.Rotate(0,0, 1);
				yield return null;
			}
			OnDrumSpinEnd?.Invoke();
		}

		public int GetCurrentNumber()
		{
			return Mathf.RoundToInt(transform.rotation.eulerAngles.z / SINGLE_NUMBER_ROTATION) + 1;
		}

		#endregion
	}
}