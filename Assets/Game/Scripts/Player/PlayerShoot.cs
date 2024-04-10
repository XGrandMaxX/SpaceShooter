using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.Scripts.Systems;
using Game.Scripts.Objects;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        #region constants
        
        public const int MISSLE_PRELOAD_COUNT = 20;
        
        #endregion
        
        #region attributs

        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private float _attackRate;

        private float _nextAttackTime;
        
        private ObjectPool<Projectile> _projectilePool;

        private PlayerInputData _inputData;
        
        #endregion

        [Inject]
        private void Construct(PlayerInputData playerInputData, InputController inputController)
        {
            _inputData = playerInputData;
            _inputData._inputController = inputController;
            _inputData._inputController.Subscribe(this, Shoot, _inputData.PlayerInput.Shoot);
            
            _projectilePool = new ObjectPool<Projectile>(
                Preload, 
                GetAction, 
                ReturnAction, 
                MISSLE_PRELOAD_COUNT);
            
            Debug.Log("PlayerShoot successfully initialize!");
        }

        private async void Shoot()
        {
            if(Time.time < _nextAttackTime)
                return;

            _nextAttackTime = Time.time + 1.0f / _attackRate;

            Projectile projectile = _projectilePool.Get();
            projectile.Launch();
            
           await DeactivateProjectile(projectile, 3);
        }
        
        private async UniTask DeactivateProjectile(Projectile projectile, float _lifeTime = 2)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_lifeTime));
            if(projectile != null || projectile.gameObject.activeInHierarchy)
                _projectilePool.Return(projectile);
        }

        private Projectile Preload() 
            => Instantiate(_projectilePrefab, transform, true);
        
        private void ReturnAction(Projectile projectile) 
            => projectile.gameObject.SetActive(false);
        
        private void GetAction(Projectile projectile)
        {
            projectile.transform.SetPositionAndRotation
                (transform.position + (Vector3)Vector2.up * 0.5f, transform.rotation);
            projectile.gameObject.SetActive(true);
        }
        
        private void OnDestroy() => _inputData._inputController.UnSubscribe(this);
    }
}
