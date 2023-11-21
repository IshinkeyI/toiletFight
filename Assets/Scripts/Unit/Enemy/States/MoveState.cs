using Unit.Enemy.States;
using Unit.Player;
using UnityEngine;

namespace Enemy.States
{
    public class MoveState : IState
    {
        private Unit.Enemy.Enemy _enemy;
        private PlayerController _player;

        #region properties
        Unit.Enemy.Enemy IState.Enemy
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
            _enemy.NavMeshAgent.isStopped = false;
        }

        public void Update()
        {
            CheckDistance();
        }

        public void Exit()
        {
            _enemy.NavMeshAgent.isStopped = true;
        }

        private void CheckDistance()
        {
            if (_enemy.IsDead)
                return;

            if (Vector3.Distance(_enemy.Transform.position, _player.Transform.position)
                > _enemy.NavMeshAgent.stoppingDistance) return;
            _enemy.NavMeshAgent.ResetPath();
            
            _enemy.SetState(_enemy.GetState<AttackState>());
        }

    }
}