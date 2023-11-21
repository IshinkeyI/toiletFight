using Map;
using System;
using UnityEngine;
using Unit.Player;
using Enemy.States;
using System.Collections.Generic;
using Unit.Enemy.States;

namespace Unit.Enemy
{
    public class Enemy : AUnit
    {
        private static readonly int Dead = Animator.StringToHash("IsDead");

        [NonSerialized] public WaveController WaveController;

        private Dictionary<Type, IState> _statesMap;
        private PlayerController _playerController;
        private IState _currentState;

        public PlayerController PlayerController => _playerController;
        protected override void Awake()
        {
            base.Awake();
            
            _playerController = FindObjectOfType<PlayerController>();

            NavMeshAgent.SetDestination(_playerController.Transform.position);
            NavMeshAgent.stoppingDistance = 2f;
            InitializeStates();
            SetStateByDefault();
        }

        private void LateUpdate()
        {
            _currentState?.Update();
        }

        private void SetStateByDefault()
        {
            SetState(GetState<MoveState>());
        }

        public IState GetState<T>() where T : IState => _statesMap[typeof(T)];

        private void InitializeStates()
        {
            _statesMap = new Dictionary<Type, IState>
            {
                [typeof(MoveState)] = new MoveState(),
                [typeof(AttackState)] = new AttackState()
            };
            foreach (KeyValuePair<Type, IState> keyValuePair in _statesMap)
            {
                keyValuePair.Value.SetVariables(this, _playerController);
            }
        }

        public void SetState(IState newState)
        {
            if (_currentState == newState) return;
            TransitionToState(newState);
        }

        private void TransitionToState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        protected override void Death()
        {
            IsDead = true;
            Animator.SetTrigger(Dead);
            WaveController.CheckWaveComplete();
        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            UIHealth.SetHealth(MaxHealth, Health, damage);
        }
    }
}