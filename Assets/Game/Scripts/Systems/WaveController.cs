using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Scripts.ScriptableObjects.Wave;
using UnityEngine;

namespace Game.Scripts.Systems
{
    [Serializable]
    public sealed class WaveController
    {
        public event Action OnLastWaveEnded;
        
        internal WaveData WaveData;
        
        private static int _enemyCount;
        public static int EnemyCount
        {
            get => _enemyCount;
            set
            {
                _enemyCount = value;

                if (_enemyCount >= 0)
                    return;
                
                _enemyCount = 0;
            }
        }

        
        public WaveController(WaveData waveData)
        {
            WaveData = waveData;

            foreach (var enemy in WaveData.Waves.SelectMany(wave => wave.Enemy))
                EnemyCount += enemy.Amount;

            Debug.Log("WaveController successfully initialize!");
        }

        public async void LastWave()
        {
            while (EnemyCount > 0)
                await UniTask.Delay(TimeSpan.FromSeconds(3));
            
            OnLastWaveEnded?.Invoke();
            //LEVEL CLEAR!
        }
    }
}
