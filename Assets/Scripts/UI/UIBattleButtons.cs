using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIBattleButtons : MonoBehaviour
	{
		[SerializeField] private Button attackButton;
		[SerializeField] private Button defenseButton;

		private void OnEnable()
		{
			attackButton.onClick.AddListener(Events.Events.OnAttackButton);
			defenseButton.onClick.AddListener(Events.Events.OnDefenseButton);
		}

		private void OnDisable()
		{
			attackButton.onClick.RemoveAllListeners();
			defenseButton.onClick.RemoveAllListeners();
		}
	}
}