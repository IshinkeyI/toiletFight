using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Map
{
    public class WaveController : MonoBehaviour
    {
        public bool IsAllEnemiesSpawned { get; private set; }

        [SerializeField] private List<EnemySpawner> spawners;
        [field: SerializeField] public int EnemiesInWaveCount { get; private set; }

        private List<Unit.Enemy.Enemy> _enemies;

        public void NextWave()
        {
            _enemies = new List<Unit.Enemy.Enemy>();
            int count = EnemiesInWaveCount;
            foreach (var enemySpawner in spawners.Where(s => s.IsSpawned == false))
            {
                if(count == 0)
                    return;
                count--;
                var enemy = enemySpawner.Instantiate();
                enemy.WaveController = this;
                _enemies.Add(enemy);
            }

            IsAllEnemiesSpawned = spawners.All(s => s.IsSpawned);
        }

        public void CheckWaveComplete()
        {
            _enemies = _enemies.Where(x => x.IsDead == false).ToList();
            
            if (_enemies.Count != 0) return;
            
            Events.Events.OnFightComplete();
        }

        public Unit.Enemy.Enemy GetNearestEnemy()
        {
            return  _enemies.First(x => !x.IsDead);
        }
    }
}