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
        
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.BindInstance(_scoreText).WhenInjectedInto<PlayerUI>();
            Container.BindInstance(_healthImage).WhenInjectedInto<PlayerUI>();
            Container.Bind<PlayerUI>().AsSingle().NonLazy();
        }
    }
}
