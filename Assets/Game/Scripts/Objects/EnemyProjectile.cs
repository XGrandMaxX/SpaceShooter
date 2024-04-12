using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class EnemyProjectile : Projectile
    {
        public override void Launch() => base.Launch();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out PlayerCollision player))
                return;

            player.TakeDamage(Damage);
        }
    }
}
