using SavePrefs;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenuUI
{
    public class UIPropertyUpper : MonoBehaviour
    {
        [SerializeField] private Button damageUpperButton;
        [SerializeField] private Button healthUpperButton;

        private SavePrefs.SavePrefs _prefs;
        private void Awake()
        {
            _prefs = FindObjectOfType<SavePrefs.SavePrefs>();
            damageUpperButton.onClick.AddListener(() =>
            {
                var data = _prefs.SaveData;
                
                if(data.Gold < 200)
                    return;
                
                _prefs.SaveData = new SaveData(data.Damage+1, data.Health, 
                    data.Levels, data.Gold-200);
                Events.Events.OnPropertyChanged();
            });
            
            healthUpperButton.onClick.AddListener(() =>
            {
                var data = _prefs.SaveData;
                
                if(data.Gold < 200)
                    return;

                _prefs.SaveData = new SaveData(data.Damage, data.Health+1, 
                    data.Levels, data.Gold-200);
                Events.Events.OnPropertyChanged();
            });
        }
    }
}