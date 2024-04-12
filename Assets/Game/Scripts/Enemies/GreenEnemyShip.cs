using DG.Tweening;
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    public sealed class GreenEnemyShip : EnemyShip
    {
        protected internal override void Initialize(Transform spawnPoint, Transform endPoint)
        {
             _playerShoot = FindObjectOfType<PlayerShoot>();
            InitializeNewData();
            
            transform.position = spawnPoint.position;

            _tween = DOTween.Sequence()
                .Append(transform.DOMove(endPoint.position, newData.MoveDuration).SetEase(Ease.OutQuart))
                .AppendCallback(() => Die(_tween, true));
        }
    }
}
