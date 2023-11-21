using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject completeObject;
        [SerializeField] private GameObject failedObject;
        
        private void OnEnable()
        {
            Events.Events.LevelComplete += LevelComplete;
            Events.Events.LevelFailed += LevelFailed;
        }

        private void OnDisable()
        {
            Events.Events.LevelComplete -= LevelComplete;
            Events.Events.LevelFailed -= LevelFailed;
        }

        private void LevelFailed()
        {
            failedObject.SetActive(true);
        }
        
        private void LevelComplete()
        {
            completeObject.SetActive(true);
        }
    }
}