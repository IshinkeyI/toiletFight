using System;
using System.Collections;
using Map;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public bool IsDead { get; private set; }
        // [NonSerialized]
        public WaveController WaveController;

        public void Death()
        {
            IsDead = true;
            WaveController.CheckWaveComplete();
        }

        private void Awake()
        {
            StartCoroutine(test());
        }

        public IEnumerator test()
        {
            yield return new WaitForSeconds(1f);
            Death();
        }
    }
}