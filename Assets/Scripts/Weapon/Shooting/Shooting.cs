namespace Weapon.Shooting
{
	public class Shooting
	{
		private BulletStats _bulletStats;
		private DispersionStats _dispersionStats;
		
		public Shooting(BulletStats bulletStats, DispersionStats dispersionStats)
		{
			_dispersionStats = dispersionStats;
			_bulletStats = bulletStats;
		}
		
	}
}
