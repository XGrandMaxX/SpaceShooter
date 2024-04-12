using System;
using DG.Tweening;
using Game.Scripts.Enemies;
using Game.Scripts.Objects;
using Game.Scripts.Objects.Buffs;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public sealed class PlayerCollision : MonoBehaviour
    {
        public event Action OnDied;
        
        private const int MAX_HEALTH = 4;
                
        private int _health = 4;
        internal int Health
        {
            get => _health;
            private set
            {
                _health = value;

                if (_health > MAX_HEALTH)
                    _health = MAX_HEALTH;
            }
        }
        
        [Inject] private PlayerUI _playerUI;
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out EnemyShip enemy))
                TakeDamage();
            
            else if (other.gameObject.TryGetComponent(out EnemyProjectile enemyProjectile))
                TakeDamage(enemyProjectile.Damage);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.TryGetComponent(out HealBuff buff))
                Heal(buff.BuffAmount);
            
            Destroy(other.gameObject);
        }

        public void TakeDamage(byte amount = 1) => ModifyHealth(-amount);

        public void Heal(byte amount = 1) => ModifyHealth(amount);
        
        private void ModifyHealth(int amount)
        {
            Health += amount;

            DOTween.Sequence()
                .Append(_playerUI.HealthImage.DOFillAmount((float)Health / MAX_HEALTH, 1))
                .JoinCallback(() =>
                {
                    if (Health > 0) 
                        return;

                    GetComponent<Collider2D>().enabled = false;
                    
                    transform.DORotate(
                        new Vector3(0, 0, 720), 
                        1,
                        RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
                    
                    transform.DOScale(Vector3.zero, 1).SetEase(Ease.InCubic)
                        .OnComplete(Die);
                });
        }

        private void Die()
        {
            OnDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
