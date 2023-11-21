using UnityEngine;

namespace SavePrefs
{
	public class SaveData
	{
		public readonly int Damage;
		public readonly int Health;
		public readonly int Levels;
		public readonly int Gold;
		
		public SaveData(int damage, int health, int levels, int gold)
		{
			Damage = damage;
			Health = health;
			Levels = levels;
			Gold   = gold;
		}
	}
	
	public class SavePrefs : MonoBehaviour
	{
		private const string DAMAGE = "Damage";
		private const string HEALTH = "Health";
		private const string LEVELS = "Levels";
		private const string GOLD = "Gold";
		private const string SAVED_GAME_EXISTS = "SavedGameExists";

		public SaveData SaveData;

		private void OnEnable()
		{
			Events.Events.LevelComplete += LevelComplete;
		}

		private void OnDisable()
		{
			Events.Events.LevelComplete -= LevelComplete;
		}

		private void Awake()
		{
			if (PlayerPrefs.HasKey(SAVED_GAME_EXISTS) && PlayerPrefs.GetInt(SAVED_GAME_EXISTS) == 1)
			{
				SaveData = Load();
			}
			else
			{
				SaveData = new SaveData(1, 10, 0, 100);
			}
		}

		private static void Save(SaveData saveData)
		{
			PlayerPrefs.SetInt(DAMAGE, saveData.Damage);
			PlayerPrefs.SetInt(HEALTH, saveData.Health);
			PlayerPrefs.SetInt(LEVELS, saveData.Levels);
			PlayerPrefs.SetInt(GOLD, saveData.Gold);

			PlayerPrefs.SetInt(SAVED_GAME_EXISTS, 1);
		}

		private static SaveData Load()
		{
			int damage = PlayerPrefs.GetInt(DAMAGE);
			int health = PlayerPrefs.GetInt(HEALTH);
			int levels = PlayerPrefs.GetInt(LEVELS);
			int gold = PlayerPrefs.GetInt(GOLD);
			
			return new SaveData(damage, health, levels, gold);
		}

		private void LevelComplete()
		{
			Save(new SaveData(SaveData.Damage, SaveData.Health, 
				SaveData.Levels >= 2 ? 0 : SaveData.Levels + 1,SaveData.Gold + 200));
		}
		
		private void OnApplicationQuit()
		{
			Save(SaveData);
		}
	}
}