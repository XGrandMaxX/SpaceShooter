using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Systems;
using Game.Scripts.Objects;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Scripts.Player
{
    public sealed class PlayerShoot : MonoBehaviour
    {
        #region constants
        
        public const int PROJECTILE_PRELOAD_COUNT = 20;
        
        #endregion
        
        #region attributs

        [FormerlySerializedAs("_projectilePrefab")] 
        [SerializeField] private PlayerProjectile playerProjectilePrefab;
        [SerializeField] private float _attackRate;

        private float _nextAttackTime;
        
        private bool _attacking;
        
        private ObjectPool<PlayerProjectile> _projectilePool;

        private PlayerInputData _inputData;
        
        #endregion

        [Inject]
        private void Construct(PlayerInputData playerInputData, InputController inputController)
        {
            _inputData = playerInputData;
            _inputData._inputController = inputController;
            _inputData._inputController.Subscribe(
                this,
                ShootPerformedAsync,
                ShootCanceled,
                _inputData.PlayerInput.Shoot);
            
            _projectilePool = new ObjectPool<PlayerProjectile>(
                Preload,
                GetAction,
                ReturnAction,
                PROJECTILE_PRELOAD_COUNT);
            
            Debug.Log("PlayerShoot successfully initialize!");
        }

        private void FixedUpdate()
        {
            if (_attacking)
                ShootPerformedAsync();
        }

        private async void ShootPerformedAsync()
        {
            if(Time.time < _nextAttackTime)
                return;

            _attacking = true;
            
            _nextAttackTime = Time.time + 1.0f / _attackRate;

            PlayerProjectile playerProjectile = _projectilePool.Get();
            playerProjectile.Launch();
            
           await DeactivateProjectileAsync(playerProjectile, playerProjectile.LifeTime);
        }
        private void ShootCanceled() => _attacking = false;
        
        public async UniTask DeactivateProjectileAsync(PlayerProjectile playerProjectile, float _lifeTime)
        {
            
            await UniTask.Delay(TimeSpan.FromSeconds(_lifeTime));
            
            if(playerProjectile.gameObject.activeInHierarchy)
                _projectilePool.Return(playerProjectile);
        }

        private PlayerProjectile Preload() 
            => Instantiate(playerProjectilePrefab, transform, true);
        
        private void ReturnAction(PlayerProjectile playerProjectile) 
            => playerProjectile.gameObject.SetActive(false);
        
        private void GetAction(PlayerProjectile playerProjectile)
        {
            playerProjectile.transform.SetPositionAndRotation
                (transform.position + (Vector3)Vector2.up * 0.5f, transform.rotation);
            playerProjectile.gameObject.SetActive(true);
        }

        private void OnDestroy() => _inputData._inputController.UnSubscribe(this);
    }
}
