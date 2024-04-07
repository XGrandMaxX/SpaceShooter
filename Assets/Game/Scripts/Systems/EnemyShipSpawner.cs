using System;
using System.Collections;
using System.Threading.Tasks;
using Game.Scripts.Enemies;
using Game.Scripts.Enemies.Factory;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Scripts.Systems
{
    public class EnemyShipSpawner : MonoBehaviour
    {
        #region constants
        
        public const int MISSLE_PRELOAD_COUNT = 20;
        
        #endregion
        
        #region attributs
        //Тип врагов, которых должна создать фабрика
        [SerializeField] private EnemyFactory _enemyFactory;
        //Созданный фабрикой враг
        [SerializeField] private EnemyShip _enemyShip;
        
        [SerializeField] private Transform[] _pointsToSpawn;

        private ObjectPool<EnemyShip> _enemyPool;
        private WaveController _waveController;
        
        #endregion
        
        #region constructors
        
        [Inject]
        private void Construct(WaveController waveController)
        {
            _waveController = waveController;
            _waveController.OnWaveEnded += SpawnEnemy;
            
            if (_enemyFactory != null)
                _enemyShip = _enemyFactory.CreateEnemy();
            
            _enemyPool = new ObjectPool<EnemyShip>(
                Preload, 
                GetAction, 
                ReturnAction, 
                MISSLE_PRELOAD_COUNT);
            
            SpawnEnemy(3);
        }
        
        #endregion
        
        #region methods

        private void SpawnEnemy(float waveDelay) => StartCoroutine(WaveSpawnDelay(waveDelay));

        private IEnumerator WaveSpawnDelay(float delay)
        {
            //Логика одновременного спавна в рандомных точках рандомных врагов
            yield return new WaitForSeconds(delay);
            
            int randomIndex = Random.Range(0, _pointsToSpawn.Length);
            Instantiate(_enemyShip, _pointsToSpawn[randomIndex].position, Quaternion.identity);
        }
        
        private async void DeactivateProjectile(EnemyShip projectile, float _lifeTime = 2)
        {
            await Task.Delay(TimeSpan.FromSeconds(_lifeTime));
            _enemyPool.Return(projectile);
        }
        
        #endregion
        
        #region pool methods
        
        private EnemyShip Preload() 
            => Instantiate(_enemyShip, transform, true);
        
        private void ReturnAction(EnemyShip projectile) 
            => projectile.gameObject.SetActive(false);
        
        private void GetAction(EnemyShip projectile)
        {
            projectile.transform.SetPositionAndRotation
                (transform.position + (Vector3)Vector2.up * 0.5f, transform.rotation);
            projectile.gameObject.SetActive(true);
        }
        
        #endregion
    }
}
