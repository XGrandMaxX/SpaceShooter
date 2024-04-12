using Game.Scripts.ScriptableObjects.Wave;
using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public sealed class WaveInstaller : MonoInstaller
    {
        [SerializeField] private WaveData _waveData;
        
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<WaveData>().FromInstance(_waveData).AsSingle().NonLazy();
            Container.Bind<WaveController>().AsSingle().NonLazy();
        }
    }
}
