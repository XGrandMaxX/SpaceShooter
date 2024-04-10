using System;
using Game.Scripts.ScriptableObjects.Enemy;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    [Serializable]
    public abstract class EnemyShip : MonoBehaviour
    {
        [SerializeField] internal EnemyData _enemyData;
    }
}
