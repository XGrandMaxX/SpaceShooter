using Game.Scripts.Enemies;
using Game.Scripts.Enemies.Factory;
using UnityEngine;

namespace Game.Scripts.Systems
{
    public class EnemyShipSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        private EnemyShip _enemyShip;
        private void Start()
        {
            if (_enemyFactory != null)
                _enemyShip = _enemyFactory.CreateEnemy();
            
            _enemyShip.Attack();
        }
    }
}
