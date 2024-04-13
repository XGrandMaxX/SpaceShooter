using DG.Tweening;
using Game.Scripts.Enemies;
using Game.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class PlayerUI
    {
        [Inject] private GameObject _gameOverPanel;
        [Inject] private TMP_Text _scoreText;
        [Inject] internal Image HealthImage;

        private readonly IPlayerCollision _player;
        internal int ScoreInScene { get; private set; }

        public PlayerUI(IPlayerCollision playerCollision)
        {
            _player = playerCollision;
            _player.OnDied += EnableGameOverPanel;
            
            Debug.Log("PlayerUI Successfully Initialize");
        }
        ~PlayerUI() => _player.OnDied -= EnableGameOverPanel;
        
        public void Subscribe(EnemyShip enemy) => enemy.OnDied += ScoreDisplay;
        private void ScoreDisplay(int amount)
        {
            ScoreInScene = int.Parse(_scoreText.text);
            _scoreText.text = $"{ScoreInScene + amount}";

            DOTween.Sequence()
                .Append(_scoreText.transform.DOScale(Vector3.one * 1.2f, 0.1f))
                .AppendInterval(0.1f)
                .Append(_scoreText.transform.DOScale(Vector3.one, 0.1f));
        }

        private void EnableGameOverPanel() => _gameOverPanel.SetActive(true);
    }
}
