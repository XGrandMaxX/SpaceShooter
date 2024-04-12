using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enemies;
using Game.Scripts.ScriptableObjects.Wave;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Game.Scripts.Systems
{
    public sealed class EnemyShipSpawner
    {
        #region Inject attributs

        [Inject] private Transform parentTransform;
        private Transform[] _spawnPositions;
        private Transform[] _endPositions;

        #endregion
        
        #region attributs
        
        private WaveData _waveData => _waveController.WaveData;
        private List<Wave> _waves => _waveData.Waves;
        
        private List<UniTask> deactivateTasks;
        
        private ObjectPool<EnemyShip> _enemyPool;
        
        private WaveController _waveController;

        private PlayerUI _playerUI;

        #endregion
        
        public EnemyShipSpawner(
            WaveController waveController,
            PlayerUI playerUI,
            [Inject(Id = "SpawnPositions")] Transform[] spawnPositions,
            [Inject(Id = "EndPositions")] Transform[] endPositions)
        {
            _spawnPositions = spawnPositions;
            _endPositions = endPositions;
            
            _waveController = waveController;
            
            _playerUI = playerUI;
            
            SpawnEnemiesAsync();
            
            Debug.Log("EnemyShipSpawner successfully initialize!");
        }
        
        //TODO: I know that a EnemyFactory + ObjectPool is needed, but I couldn't do it :c
        private async void SpawnEnemiesAsync()
        {
            int randomSpawnPosition = 0;
            int randomEndPosition = 0;
            int enemyIndex = 0;
            Wave wave;
            
            for (int waveIndex = _waveData.CurrentWaveNumber; waveIndex < _waves.Count; waveIndex++)
            {
                 wave = _waves[waveIndex];

                NextWaveAsync(wave, randomSpawnPosition, randomEndPosition, enemyIndex, waveIndex);
                enemyIndex = 0;
                
                await UniTask.Delay(TimeSpan.FromSeconds(_waves[waveIndex].NextWaveDelay));
            }
                            
            _waveController.LastWave();
        }

        private async void NextWaveAsync(
            Wave wave,
            int randomSpawnPosition, 
            int randomEndPosition,
            int enemyIndex,
            int waveIndex)
        {
            foreach (var enemy in wave.Enemy)
            {
                randomSpawnPosition = Random.Range(0, _spawnPositions.Length);
                randomEndPosition = Random.Range(0, _endPositions.Length);

                for (int i = 0; i < enemy.Amount; i++)
                {
                    EnemyShip enemyShip = Object.Instantiate(
                        wave.Enemy[enemyIndex].SpawnPrefab,
                        parentTransform,
                        true);

                    enemyShip.Initialize(_spawnPositions[randomSpawnPosition], _endPositions[randomEndPosition]);

                    _playerUI.Subscribe(enemyShip);

                    await UniTask.Delay(TimeSpan.FromSeconds(_waves[waveIndex].Enemy[enemyIndex].SpawnDelay));
                }
                enemyIndex += 1;
            }
        }
    }
}
