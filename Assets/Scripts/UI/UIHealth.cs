using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private Transform textTransform;
        [SerializeField] private Image healthImage;

        private TextMeshProUGUI _textMeshPro;
        
        public void SetHealth(int maxHealth, int currentHealth, int damage)
        {
            _textMeshPro ??= textTransform.GetComponent<TextMeshProUGUI>();
            _textMeshPro.text = $"-{damage}";
            healthImage.fillAmount = (float)currentHealth / maxHealth;
            StartCoroutine(ChangeTextPosition());
        }

        private IEnumerator ChangeTextPosition()
        {
            textTransform.gameObject.SetActive(true);
            for (float i = 0; i < 1; i+=0.05f)
            {
                textTransform.localPosition = Vector3.Lerp(textTransform.localPosition, Vector3.zero, i);
                yield return new WaitForFixedUpdate();
            }
            textTransform.gameObject.SetActive(false);
            textTransform.localPosition = new Vector3(0, -50, 0);
        }
    }
}