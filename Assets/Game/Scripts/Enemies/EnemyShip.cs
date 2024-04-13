using System;
using DG.Tweening;
using Game.Scripts.Enemies.ScriptableObjects;
using Game.Scripts.Objects;
using Game.Scripts.Player;
using Game.Scripts.Systems;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    [Serializable]
    public abstract class EnemyShip : MonoBehaviour
    {
        protected internal event Action<int> OnDied;
        private protected PlayerShoot _playerShoot;
        
        [SerializeField] protected internal EnemyData _enemyData;
        private protected EnemyData newData;
        
        private protected Tween _tween;
        
        protected internal abstract void Initialize(Transform spawnPoint, Transform endPoint);

        protected internal virtual void Die(Tween tween, bool animationEnded = false)
        {
            if (!animationEnded)
            {
                BuffFactory.CreateBuff(transform, true);
                OnDied?.Invoke(_enemyData.Score);
            }
            
            tween.Kill();
            
            WaveController.EnemyCount -= 1; //:)
            
            Destroy(gameObject);
        }

        protected internal virtual async void TakeDamage(byte amount, PlayerProjectile projectile)
        {
            await _playerShoot.DeactivateProjectileAsync(
                projectile, 0);
            
            newData.Health -= amount;
            
            if (newData.Health <= 0)
                Die(_tween);
        }
        protected internal virtual void InitializeNewData()
        {
            newData = ScriptableObject.CreateInstance<EnemyData>();
            newData.Initialize(_enemyData.Health, _enemyData.MoveDuration);
            // newData.Health = _enemyData.Health;
            // newData.Damage = _enemyData.Damage;
            // newData.MoveDuration = _enemyData.MoveDuration;
        }
    }
}
