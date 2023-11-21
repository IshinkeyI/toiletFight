using TMPro;
using UnityEngine;

namespace UI.MainMenuUI
{
    public class UISetPropertyValues : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI damageText;
        [SerializeField] private TextMeshProUGUI healthText;

        private void OnEnable()
        {
            Events.Events.PropertyChanged += PropertyChanged;
        }

        private void OnDisable()
        {
            Events.Events.PropertyChanged -= PropertyChanged;
        }

        private void Start()
        {
            PropertyChanged();
        }

        private void PropertyChanged()
        {
            var data = FindObjectOfType<SavePrefs.SavePrefs>().SaveData;
            goldText.text = $"{data.Gold}";
            levelText.text = $"{data.Levels}";
            damageText.text = $"{data.Damage}";
            healthText.text = $"{data.Health}";
        }
    }
}
