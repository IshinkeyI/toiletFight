using UnityEngine;

namespace Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        public bool IsSpawned { get; private set; }

        public Enemy.Enemy Instantiate()
        {
            IsSpawned = true;
            Debug.Log("spawner name " + gameObject.name);
            return Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<Enemy.Enemy>();
        }
    }
}
