using UnityEngine;
using System.Collections.Generic;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spawnersList;
        [SerializeField] private PlayerSpawner playerSpawner;
        
        private WaveController _waveController;
        
        private SavePrefs.SavePrefs _savePrefs;

        private void OnEnable()
        {
            Events.Events.FightComplete += OnFightComplete;
            Events.Events.LevelComplete += OnLevelComplete;
        }

        private void OnDisable()
        {
            Events.Events.FightComplete -= OnFightComplete;
            Events.Events.LevelComplete -= OnLevelComplete;
        }

        private void Awake()
        {
            _savePrefs = FindObjectOfType<SavePrefs.SavePrefs>();
            foreach (var o in spawnersList) 
                o.SetActive(false);

            int currentLevel =
                spawnersList.Count > _savePrefs.SaveData.Levels 
                ? _savePrefs.SaveData.Levels
                : spawnersList.Count - 1;
            
            spawnersList[currentLevel].SetActive(true);
            _waveController = spawnersList[currentLevel].GetComponent<WaveController>();

            playerSpawner.InstantiatePlayer();
            _waveController.NextWave();
        }

        private void OnFightComplete()
        {
            if(_waveController.IsAllEnemiesSpawned)
            {
                Events.Events.OnLevelComplete();
            }
            else
            {
                _waveController.NextWave();
            }
        }

        private void OnLevelComplete()
        {
            Debug.Log("level complete");
        }
    }
}