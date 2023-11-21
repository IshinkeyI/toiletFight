using UnityEngine;

namespace Unit.Player.AnimatorBehaviors
{
	public class PlayerAttackBehavior : StateMachineBehaviour
	{
		private PlayerController _player;
		private static readonly int Idle = Animator.StringToHash("Idle");

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);

			_player ??= animator.GetComponent<PlayerController>();
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			base.OnStateEnter(animator, stateInfo, layerIndex);
			
			_player.Animator.SetBool(Idle, true);
		}
	}
}