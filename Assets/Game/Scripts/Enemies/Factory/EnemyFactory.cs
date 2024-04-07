using UnityEngine;

namespace Game.Scripts.Enemies.Factory
{
    public abstract class EnemyFactory : ScriptableObject
    {
        [SerializeField] protected EnemyShip _objectPrefab;
        public abstract EnemyShip CreateEnemy();
    }

    
    [CreateAssetMenu(menuName = "Factory/RedShip", fileName = "RedShip")]
    public class RedEnemyFactory : EnemyFactory
    {
        public override EnemyShip CreateEnemy()
        {
            Debug.Log("SPAWNED!");
           return _objectPrefab as RedEnemyShip;
        }
    }

    [CreateAssetMenu(menuName = "Factory/BlueShip", fileName = "BlueShip")]
    public class BlueEnemyFactory : EnemyFactory
    {
        public override EnemyShip CreateEnemy()
        {
            Debug.Log($"Enemy - {_objectPrefab as BlueEnemyShip} successfully created!");
            return _objectPrefab as BlueEnemyShip;
        }
    }
}
