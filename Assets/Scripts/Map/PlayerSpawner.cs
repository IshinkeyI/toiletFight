using Unit.Player;
using UnityEngine;

namespace Map
{
	public class PlayerSpawner : MonoBehaviour
	{
		[SerializeField] private SOCharacter characterSo;

		public void InstantiatePlayer()
		{
			var savePrefs = FindObjectOfType<SavePrefs.SavePrefs>();
			var player = Instantiate(characterSo.PlayerPrefab, transform.position, Quaternion.identity).
					GetComponent<PlayerController>();
			player.Damage = savePrefs.SaveData.Damage;
			player.Health = savePrefs.SaveData.Health;
			
			FindObjectOfType<CameraController.CameraController>().SetFollow(player.transform);
		}
	}
}