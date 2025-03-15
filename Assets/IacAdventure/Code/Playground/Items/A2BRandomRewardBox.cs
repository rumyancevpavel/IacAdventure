using UnityEngine;

namespace IacAdventure.Playground.Items
{
	public class A2BRandomRewardBox : MonoBehaviour
	{
		[SerializeField] private Transform _a2bCollectItemTarget;
		[SerializeField] private Transform _a2bCollectItemStart;
		[SerializeField] private GameObject[] _prefabRefs;
		[SerializeField] private float _speed;
		
		public void Interact()
		{
		}

		private GameObject CreateRandomItem(Vector3 atPosition)
		{
			var prefabRef = _prefabRefs[Random.Range(0, _prefabRefs.Length)];
			return Instantiate(prefabRef, atPosition, Quaternion.identity);
		}
	}
}