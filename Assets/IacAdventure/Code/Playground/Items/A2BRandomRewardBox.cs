using System.Collections;
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
			StartCoroutine(FlyToTargetCoroutine(item, _a2bCollectItemTarget));
		}

		private GameObject CreateRandomItem()
		{
			var prefabRef = _prefabRefs[Random.Range(0, _prefabRefs.Length)];
			return Instantiate(prefabRef, _a2bCollectItemStart.position, Quaternion.identity);
		}

		private IEnumerator FlyToTargetCoroutine(GameObject item, Transform target)
		{
			while (Vector3.Distance(item.transform.position, target.position) > 0.1f)
			{
				item.transform.position = Vector3.MoveTowards(item.transform.position, target.position, _speed * Time.deltaTime);
				yield return null;
			}
			Destroy(item);
		}
	}
}