using UnityEngine;

namespace Map
{
	[CreateAssetMenu(fileName = "Characters", menuName = "Characters/New character")]
	public class SOCharacter : ScriptableObject
	{
		[field: SerializeField] public GameObject PlayerPrefab { get; private set; }

	}
}