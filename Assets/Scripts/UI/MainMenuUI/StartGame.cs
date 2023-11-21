using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI.MainMenuUI
{
	public class StartGame : MonoBehaviour
	{
		[SerializeField] private Button startGameButton;

		private void Awake()
		{
			startGameButton.onClick.AddListener(() =>
			{
				SceneManager.LoadScene(sceneBuildIndex: 1);
			});
		}
	}
}