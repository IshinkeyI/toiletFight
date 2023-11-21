using Unit.Player;

namespace Enemy.States
{
    public interface IState
    {
        public Unit.Enemy.Enemy Enemy { get; protected set; }
        public PlayerController Player { get; protected set; }


        public void SetVariables(Unit.Enemy.Enemy enemy, PlayerController player)
        {
            Enemy = enemy;
            Player = player;
        }
        public void Enter();
        public void Update();
        public void Exit();
    }
}