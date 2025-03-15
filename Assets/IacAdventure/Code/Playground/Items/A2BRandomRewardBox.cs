using System.Collections;
using IacAdventure.Gameplay.Tools;
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
			var item = CreateRandomItem();
			StartCoroutine(A2bHelper.FlyToTargetCoroutine(item, _a2bCollectItemTarget, _speed));
		}

		private GameObject CreateRandomItem()
		{
			var prefabRef = _prefabRefs[Random.Range(0, _prefabRefs.Length)];
			return Instantiate(prefabRef, _a2bCollectItemStart.position, Quaternion.identity);
		}
	}
}