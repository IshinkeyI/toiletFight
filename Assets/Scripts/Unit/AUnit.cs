using System;
using UI;
using Unit.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    [RequireComponent(typeof(UIHealth))]
    public abstract class AUnit : MonoBehaviour, IDamagable
    {
        private static Action<AUnit, AUnit, int> _getDamageEvent;

        [NonSerialized] public int MaxHealth;

        protected UIHealth UIHealth;

        #region properties

        [field: SerializeField] public int Health { get; protected set; }
        [field: SerializeField] public int Damage { get; private set; }
        public bool IsDead { get; protected set; }
        public Transform Transform { get; private set; }
        public NavMeshAgent NavMeshAgent { get; private set; }
        public Animator Animator { get; private set; }
        #endregion
        private void OnEnable()
        {
            _getDamageEvent += GetDamage;
        }

        private void OnDisable()
        {
            _getDamageEvent -= GetDamage;
        }

        protected virtual void Awake()
        {
            MaxHealth = Health;
            Transform = transform;

            UIHealth = GetComponent<UIHealth>();
            Animator = GetComponent<Animator>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public static void OnGetDamageEvent(AUnit damageDealer, AUnit damageTrigger, int damage)
        {
            _getDamageEvent?.Invoke(damageDealer, damageTrigger, damage);
        }

        protected abstract void Death();

        public void GetDamage(AUnit dealer, AUnit target, int damage)
        {
            if(dealer == target)
                return;
            
            target.GetDamage(damage);
            
            if(target.Health <= 0)
                Death();
        }

        public abstract void GetDamage(int damage);
    }
}