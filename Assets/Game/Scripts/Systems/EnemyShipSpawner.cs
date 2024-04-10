using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.ScriptableObjects.Wave;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;


namespace Game.Scripts.Systems
{
    public class EnemyShipSpawner
    {
        private WaveController _waveController;
        private WaveData _waveData => _waveController.WaveData;
        private List<Wave> _waves => _waveData.Waves;

        [Inject]
        private async void Construct(WaveController waveController)
        {
            _waveController = waveController;
            
            await SpawnEnemiesAsync();
            
            Debug.Log("EnemyShipSpawner successfully initialize!");
        }

        private async UniTask SpawnEnemiesAsync()
        {
            while (_waveData.CurrentWaveNumber < _waveData.FinalWaveNumber)
            {
                for (int i = 0; i < _waves.Count; i++)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(_waves[i].NextWaveDelay));
                    
                    for (int j = 0; j < _waves[i].Enemy[j].Count; j++)
                    {
                       Object.Instantiate(_waves[i].Enemy[j].SpawnPrefab);
                        
                        await UniTask.Delay(TimeSpan.FromSeconds(_waves[i].Enemy[j].SpawnDelay));
                    }
                }
            }
        }
    }
}
