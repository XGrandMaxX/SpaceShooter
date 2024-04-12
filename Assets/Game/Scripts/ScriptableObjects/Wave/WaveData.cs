using System;
using System.Collections.Generic;
using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects.Wave
{
    [CreateAssetMenu(menuName = "newWave")]
    public sealed class WaveData : ScriptableObject
    {
        private void OnEnable() => CurrentWaveNumber = 0;

        [SerializeField] internal sbyte CurrentWaveNumber = 0;
        [SerializeField] internal List<Wave> Waves;
    }

    [Serializable]
    public struct Wave
    {
        [SerializeField] internal byte NextWaveDelay;
        [SerializeField] internal EnemySettings[] Enemy;
    }

    [Serializable]
    public struct EnemySettings
    {
        [SerializeField] internal EnemyShip SpawnPrefab;
        [SerializeField] internal float SpawnDelay;

        [Space(10)]
        [SerializeField] internal short Amount;
    }
}
