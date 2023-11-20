using Player;

namespace Enemy.States
{
    public interface IState
    {
        public Enemy Enemy { get; protected set; }
        public PlayerController Player { get; protected set; }


        public void SetVariables(Enemy enemy, PlayerController player)
        {
            Enemy = enemy;
            Player = player;
        }
        public void Enter();
        public void Update();
        public void Exit();
    }
}