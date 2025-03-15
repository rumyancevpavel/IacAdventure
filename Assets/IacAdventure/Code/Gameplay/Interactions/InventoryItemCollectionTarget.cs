using UnityEngine;

namespace IacAdventure.Gameplay.Interactions
{
	public class InventoryItemCollectionTarget : MonoBehaviour
	{
		#region Editor Exposed
		
		[SerializeField] private GameObject _inventoryItemA2BTarget;
		
		#endregion
		
		#region Singleton

		public Transform Target => _inventoryItemA2BTarget.transform;
		
		private static InventoryItemCollectionTarget _instance;

		public static InventoryItemCollectionTarget Instance => _instance;

		#endregion

		#region Methods

		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(gameObject);
				Debug.LogError("Detected attempt to duplicate instantiation of [InventoryItemCollectionTarget]");
				return;
			}
			_instance = this;
		}

		#endregion
	}
}