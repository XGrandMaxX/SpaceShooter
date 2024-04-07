using System;
using UnityEngine;

namespace Game.Scripts.Systems
{
    //Create Installer for this script
    public class WaveController
    {
        [SerializeField] private float _waveDelay;
        [SerializeField] private int _waveNumber;
        public event Action<float> OnWaveEnded;

        private void WaveEnd()
        {
            OnWaveEnded?.Invoke(_waveDelay);
            Debug.Log("Волна закончилась");
        }
    }
}
