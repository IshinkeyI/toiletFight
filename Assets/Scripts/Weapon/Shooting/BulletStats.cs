using System;
using UnityEngine;

namespace Weapon.Shooting
{
	[Serializable]
	public struct BulletStats
	{		
		[Tooltip("Урон от попадания.")]
		public int damage;
		[Tooltip("Урон от попадания в голову.")]
		public int headDamage;
		[Tooltip("Пробитие брони."),Range(0f, 1f)]
		public float armorPenetration;
		[Tooltip("Пуля.")]
		public GameObject bulletGameObject; 
		[Tooltip("Место инициализации пули.")]
		public Transform bulletSpawn;
		[Tooltip("Скорость полета пули.")]
		public float bulletSpeed;
		[Tooltip("Отталкивание живого объекта при попадании.")]
		public float rebound;
		// [Tooltip("Стихийные модификаторы.")]
		// public List<DebuffEffectType> attackModifications;
		[Tooltip("Урезание дамага при пробитии объекта."), Range(0f, 1f)]
		public float multipleHitDamageModificator;
		// [Tooltip("Все эффекты оружия.")]
		// public SOWeaponEffects weaponEffect;
		[Tooltip("Наносить ли урон по игроку(Character).")]
		public bool friendlyFire;
		[Tooltip("Эффект взрыва")]
		public GameObject explodeEffect;
		[Tooltip("Радиус взрыва")]
		public float radiusExplode;
		
		[NonSerialized] public float LifeTime;
	}
}