using Game.Scripts.Player;
using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public sealed class InputInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputData playerInputData;
        
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<InputController>().AsSingle().NonLazy();
            Container.Bind<PlayerInputData>().FromInstance(playerInputData).AsSingle();
        }
    }
}
