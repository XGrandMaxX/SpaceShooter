using Game.Scripts.Player;
using Zenject;

namespace Game.Scripts.Installers
{
    public class IPlayerCollisionInstaller : MonoInstaller
    {
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<IPlayerCollision>()
                .To<PlayerCollision>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
