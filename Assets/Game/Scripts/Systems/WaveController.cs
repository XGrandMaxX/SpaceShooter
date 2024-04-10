using System;
using Game.Scripts.ScriptableObjects.Wave;
using UnityEngine;

namespace Game.Scripts.Systems
{
    [Serializable]
    public class WaveController
    {
        public event Action OnWaveEnded;
        public event Action OnWaveStarted;

        internal WaveData WaveData;

        private int _enemyCounter = 0;
        internal int EnemyCounter
        {
            get => _enemyCounter;
            private set
            {
                _enemyCounter = value;
                if (_enemyCounter > 0) 
                    return;
                
                _enemyCounter = 0;
            }
        }

        public WaveController(WaveData waveData)
        {
            WaveData = waveData;
            
            Debug.Log("WaveController successfully initialize!");
        }

        public void CheckEnemiesOnScene()
        {
            if (EnemyCounter <= 0)
            {
                
            }
        }
        
        private void WaveEnd() => OnWaveEnded?.Invoke();
        private void WaveStart() => OnWaveStarted?.Invoke();
        

    }
}
