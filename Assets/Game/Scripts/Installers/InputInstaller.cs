using Game.Scripts.Systems;
using Zenject;

namespace Game.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<InputController>().AsSingle().NonLazy();
        }
    }
}
