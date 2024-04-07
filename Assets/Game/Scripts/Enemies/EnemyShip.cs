
namespace Game.Scripts.Enemies
{
    public abstract class EnemyShip
    {
        public abstract void Attack();

        static EnemyShip CreateDefault() => new RedEnemyShip();
    }
}
