using UnityEngine;

namespace Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        public bool IsSpawned { get; private set; }

        public Unit.Enemy.Enemy Instantiate()
        {
            IsSpawned = true;
            Debug.Log("spawner name " + gameObject.name);
            return Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<Unit.Enemy.Enemy>();
        }
    }
}
