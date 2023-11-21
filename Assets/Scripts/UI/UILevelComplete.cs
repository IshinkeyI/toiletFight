using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UILevelComplete : MonoBehaviour
    {
        [SerializeField] private Button menuButton;

        private void Awake()
        {
            menuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }
}