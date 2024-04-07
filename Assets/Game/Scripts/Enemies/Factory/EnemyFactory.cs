using UnityEngine;

namespace Game.Scripts.Enemies.Factory
{
    public abstract class EnemyFactory : ScriptableObject
    {
        public abstract EnemyShip CreateEnemy();
    }

    
    [CreateAssetMenu(menuName = "Factory/RedShip", fileName = "RedShip")]
    public class RedEnemyFactory : EnemyFactory
    {
        public override EnemyShip CreateEnemy() => new RedEnemyShip();
    }
    [CreateAssetMenu(menuName = "Factory/BlueShip", fileName = "BlueShip")]
    public class BlueEnemyFactory : EnemyFactory
    {
        public override EnemyShip CreateEnemy() => new BlueEnemyShip();
    }
}
