using Game.Scripts.Objects.Buffs;
using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class BuffInstaller : MonoInstaller
    {
        [SerializeField] private Buff[] _buffs;
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<Buff[]>()
                .WithId("Buffs")
                .FromInstance(_buffs)
                .AsTransient();
            
            Container.Bind<BuffFactory>().AsSingle().NonLazy();
        }
    }
}
