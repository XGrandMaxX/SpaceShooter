using System;
using System.Collections.Generic;
using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects.Wave
{
    [CreateAssetMenu(menuName = "newWave")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] internal float CurrentWaveNumber;
        [SerializeField] internal float FinalWaveNumber;
        [SerializeField] internal List<Wave> Waves;
    }

    [Serializable]
    public struct Wave
    {
        [SerializeField] internal float NextWaveDelay;
        [SerializeField] internal EnemySettings[] Enemy;
    }

    [Serializable]
    public struct EnemySettings
    {
        [SerializeField] internal EnemyShip SpawnPrefab;
        [SerializeField] internal float SpawnDelay;
        
        [Space(10)]
        
        [SerializeField] internal int Count;
        [SerializeField] internal float Level;
    }
}
