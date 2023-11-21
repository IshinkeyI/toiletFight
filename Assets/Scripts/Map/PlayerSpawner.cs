using UnityEngine;

namespace Map
{
	public class PlayerSpawner : MonoBehaviour
	{
		[SerializeField] private SOCharacter characterSo;

		public void InstantiatePlayer()
		{
			Instantiate(characterSo.PlayerPrefab, transform.position, Quaternion.identity);
		}
	}
}