using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class PlayerProjectile : Projectile
    {
        public override void Launch() => base.Launch();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out EnemyShip enemy))
                return;

            enemy.TakeDamage(Damage, this);
        }
    }
}
