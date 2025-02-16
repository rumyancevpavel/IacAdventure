namespace IacAdventure.Gameplay.Inventory
{
	public class GameInventory
	{
		public static int GoldAmount { get; private set; }
		public static int GemsAmount { get; private set; }
		public static int ExperienceAmount { get; private set; }

		
		public static void AddGold(int amount)
		{
			GoldAmount += amount;
		}

		public static void AddExperience(int amount)
		{
			ExperienceAmount += amount;
		}

		public static void AddGems(int amount)
		{
			GemsAmount += amount;
		}
	}
}