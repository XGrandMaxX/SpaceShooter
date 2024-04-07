using System;
using System.Threading.Tasks;
using Game.Scripts.Systems;
using Game.Scripts.Objects;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        #region constants
        
        private const int MISSLE_PRELOAD_COUNT = 20;

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

        private void OnDestroy() => _inputData._inputController.UnSubscribe(this);

        private void Shoot()
        {
            if(Time.time < _nextAttackTime)
                return;

            _nextAttackTime = Time.time + 1.0f / _attackRate;

            Projectile projectile = _projectilePool.Get();
            projectile.Launch();
            
            DeactivateProjectile(projectile, 3);
        }
        
        private async void DeactivateProjectile(Projectile projectile, float _lifeTime = 2)
        {
            await Task.Delay(TimeSpan.FromSeconds(_lifeTime));
            _projectilePool.Return(projectile);
        }

        public Projectile Preload() 
            => Instantiate(_projectilePrefab, transform, true);
        
        public void ReturnAction(Projectile projectile) 
            => projectile.gameObject.SetActive(false);
        
        public void GetAction(Projectile projectile)
        {
            projectile.transform.SetPositionAndRotation
                (transform.position + (Vector3)Vector2.up * 0.5f, transform.rotation);
            projectile.gameObject.SetActive(true);
        }
    }
}
