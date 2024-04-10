using Game.Scripts.ScriptableObjects.Wave;
using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class WaveInstaller : MonoInstaller
    {
        [SerializeField] private WaveData _waveData;
        public override void InstallBindings() => Bind();

        private void Bind()
        {
            Container.Bind<WaveController>().AsSingle().NonLazy();
            Container.Bind<WaveData>().FromInstance(_waveData).AsTransient().NonLazy();
        }
    }
}
