using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class BlueEnemyShip : EnemyShip
    {
        public override void Attack()
        {
            Debug.Log("Blue attack!");
        }
    }
}
