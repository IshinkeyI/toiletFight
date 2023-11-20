using Map;
using Player;
using System;
using UnityEngine;
using Enemy.States;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public bool IsDead { get; private set; }
        public Transform Transform { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }

        [NonSerialized] public WaveController WaveController;

        private Dictionary<Type, IState> _statesMap;
        private PlayerController _playerController;
        private IState _currentState;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            Transform = transform;

            NavMeshAgent = GetComponent<NavMeshAgent>();
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

        public void Death()
        {
            IsDead = true;
            WaveController.CheckWaveComplete();
        }
    }
}