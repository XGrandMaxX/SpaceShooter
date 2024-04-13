using Game.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Installers
{
    public sealed class PlayerUIInstaller : MonoInstaller
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Image _healthImage;
        [SerializeField] private GameObject _gameOverPanel;
        
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.BindInstance(_scoreText).WhenInjectedInto<PlayerUI>();
            Container.BindInstance(_healthImage).WhenInjectedInto<PlayerUI>();
            Container.BindInstance(_gameOverPanel).WhenInjectedInto<PlayerUI>();
            Container.Bind<PlayerUI>().AsSingle().NonLazy();
        }
    }
}
