using System;
using UnityEngine;

namespace Weapon.Shooting
{
	[Serializable]
	public struct DispersionStats
	{
		[SerializeField, Tooltip("Отклонение для начальной стрельбы."), Range(0f, 1f)]
		private float singleShotDeviation;
		[SerializeField, Tooltip("Отклонение для продолжительной стрельбы."), Range(0f, 1f)]
		private float burstShotDeviation;
		[SerializeField, Tooltip("Максимальное отклонение, так же используется для разброса солдат и дробовика."), Range(0f, 1f)]
		private float maxDeviation;
		[SerializeField, Tooltip("Количество пуль, после которых стрельба считается продолжительной.")]
		private int continuousShotsToApplyBurst;
		[SerializeField, Tooltip("Разброс при движении."), Range(1f, 5f)]
		private float movementModifier;

		#region Properties

		public float SingleShotDeviation
		{
			get => singleShotDeviation;
			set => singleShotDeviation = value;
		}

		public float BurstShotDeviation
		{
			get => burstShotDeviation;
			set => burstShotDeviation = value;
		}

		public float MaxDeviation
		{
			get => maxDeviation;
			set => maxDeviation = value;
		}

		public int ContinuousShotsToApplyBurst
		{
			get => continuousShotsToApplyBurst;
			set => continuousShotsToApplyBurst = value;
		}

		public float MovementModifier
		{
			get => movementModifier;
			set => movementModifier = value;
		}

		#endregion

		public DispersionStats(float singleShotDeviation, float burstShotDeviation, float maxDeviation,
			int continuousShotsToApplyBurst, float movementModifier)
		{
			this.singleShotDeviation = singleShotDeviation;
			this.burstShotDeviation = burstShotDeviation;
			this.maxDeviation = maxDeviation;
			this.continuousShotsToApplyBurst = continuousShotsToApplyBurst;
			this.movementModifier = movementModifier;
		}
	}
}