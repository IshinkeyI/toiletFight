using Unit.Player;
using UnityEngine;

namespace Unit.Enemy.States.AnimatorBehaviors
{
    public class AttackBehavior : StateMachineBehaviour
    {
        private Enemy _enemy;
        private PlayerController _player;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _enemy ??= animator.GetComponent<Enemy>();
            _player ??= _enemy.PlayerController;
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            AUnit.OnGetDamageEvent(_enemy, _player, _enemy.Damage);
        }
    }
}