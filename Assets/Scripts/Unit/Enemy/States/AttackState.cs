using Enemy.States;
using Unit.Player;
using UnityEngine;

namespace Unit.Enemy.States
{
    public class AttackState : IState
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        private Enemy _enemy;
        private PlayerController _player;

        #region properties
        Enemy IState.Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        PlayerController IState.Player
        {
            get => _player;
            set => _player = value;
        }

        #endregion

        public void Enter()
        {
            _enemy.Animator.SetBool(IsAttacking, true);
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}