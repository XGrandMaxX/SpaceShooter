using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class RedEnemyShip : EnemyShip
    {
        public override void Attack()
        {
            Debug.Log("Red attack!");
        }
    }
}
