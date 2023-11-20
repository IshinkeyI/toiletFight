using Player;

namespace Enemy.States
{
    public class AttackState : IState
    {
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
            
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}