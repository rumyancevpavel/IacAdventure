using System.Collections;
using UnityEngine;

namespace IacAdventure.Gameplay.Tools
{
	public static class A2bHelper
	{
		public static IEnumerator FlyToTargetCoroutine(GameObject item, Transform target, float speed)
		{
			while (Vector3.Distance(item.transform.position, target.position) > 0.1f)
			{
				item.transform.position = Vector3.MoveTowards(item.transform.position, target.position, speed * Time.deltaTime);
				yield return null;
			}
			Object.Destroy(item);
		}
	}
}