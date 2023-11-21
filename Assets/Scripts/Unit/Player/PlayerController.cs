using Map;
using UnityEngine;

namespace Unit.Player
{
    public class PlayerController : AUnit
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Idle = Animator.StringToHash("Idle");

        private WaveController _waveController;

        private Enemy.Enemy _nearestEnemy;
        
        private bool _isDefence;
        private static readonly int Defence = Animator.StringToHash("Defence");

        protected override void OnEnable()
        {
            base.OnEnable();
            Events.Events.AttackButton += AttackButton;
            Events.Events.DefenseButton += DefenseButton;
            Events.Events.FightComplete += FightComplete;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Events.Events.AttackButton -= AttackButton;
            Events.Events.DefenseButton -= DefenseButton;
            Events.Events.FightComplete -= FightComplete;
        }

        protected override void Awake()
        {
            base.Awake();

            _waveController = FindObjectOfType<WaveController>();
            NavMeshAgent.stoppingDistance = 2f;
        }

        protected void LateUpdate()
        {
            CheckDistance();
        }

        protected override void Death()
        {
            Events.Events.OnLevelFailed();
        }

        public override void GetDamage(int damage)
        {
            if(_isDefence)
                return;

            Health -= damage;
            UIHealth.SetHealth(MaxHealth, Health, damage);
        }

        private void AttackButton()
        {
            if(Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                return;
            if(_nearestEnemy == null)
                 return;
            
            Animator.SetTrigger(Attack);
            
            OnGetDamageEvent(this, _nearestEnemy, Damage);
        }

        private void DefenseButton()
        {
            Animator.SetBool(Defence, true);
        }
        
        private void CheckDistance()
        {
            _nearestEnemy = _waveController.GetNearestEnemy();
            var nearestEnemyPosition =_nearestEnemy.Transform.position;
            
            NavMeshAgent.SetDestination(nearestEnemyPosition);
            
            if (Vector3.Distance(Transform.position, nearestEnemyPosition)
                > NavMeshAgent.stoppingDistance)
            {
                _nearestEnemy = null;
                return;
            }
            Animator.SetBool(Idle, true);
            NavMeshAgent.ResetPath();
        }

        private void FightComplete()
        {
            Animator.SetBool(Idle, false);
        }

        public void DefenceStarted()
        {
            _isDefence = true;
        }

        public void DefenceCanceled()
        {
            _isDefence = false;
            Animator.SetBool(Defence, false);
            Animator.SetBool(Idle, true);
        }
    }
}
