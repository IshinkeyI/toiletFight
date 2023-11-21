namespace Unit.Player
{
    public class PlayerController : AUnit
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Death()
        {
            throw new System.NotImplementedException();
        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            UIHealth.SetHealth(MaxHealth, Health, damage);
        }
    }
}
