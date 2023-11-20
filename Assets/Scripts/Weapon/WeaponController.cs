using UnityEngine;
using Weapon.Shooting;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private BulletStats bulletStats;
        [SerializeField] private DispersionStats dispersionStats;
        private Shooting.Shooting _shooting;

        private void Awake()
        {
            _shooting = new Shooting.Shooting(bulletStats, dispersionStats);
        }
    }
}
