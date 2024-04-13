using Game.Scripts.ScriptableObjects.Wave;
using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public sealed class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _endPositions;
        [SerializeField] private Transform _parentTransform;
        
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<Transform[]>()
                .WithId("SpawnPositions")
                .FromInstance(_spawnPositions)
                .AsTransient();
            
            Container.Bind<Transform[]>()
                .WithId("EndPositions")
                .FromInstance(_endPositions)
                .AsTransient();
            
            Container.BindInstance(_parentTransform).WhenInjectedInto<EnemyShipSpawner>();
            Container.Bind<EnemyShipSpawner>().AsSingle().NonLazy();
        }
    }
}
