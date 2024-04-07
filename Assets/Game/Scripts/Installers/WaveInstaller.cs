using Game.Scripts.Systems;
using Zenject;

namespace Game.Scripts.Installers
{
    public class WaveInstaller : MonoInstaller
    {
        public override void InstallBindings() => Bind();

        private void Bind() => Container.Bind<WaveController>().AsSingle().NonLazy();
    }
}
