using System.Collections;
using UnityEngine;

namespace Unit.Player.AnimatorBehaviors
{
	public class PlayerDefenceBehavior : StateMachineBehaviour
	{
		private PlayerController _player;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			
			_player ??= animator.GetComponent<PlayerController>();
			
			_player.DefenceStarted();
			_player.StartCoroutine(Exit());
		}

		private IEnumerator Exit()
		{
			yield return new WaitForSeconds(0.5f);
			_player.DefenceCanceled();
		}
	}
}