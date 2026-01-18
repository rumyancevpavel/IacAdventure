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
			transform.Rotate(0,0, SINGLE_NUMBER_ROTATION);
		}

		#endregion
	}
}