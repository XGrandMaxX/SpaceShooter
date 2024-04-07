using Game.Scripts.Player;
using Game.Scripts.Systems;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_playerData")] [SerializeField] private PlayerInputData playerInputData;
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<InputController>().AsSingle().NonLazy();
            Container.Bind<PlayerInputData>().FromInstance(playerInputData).AsSingle();
        }
    }
}
