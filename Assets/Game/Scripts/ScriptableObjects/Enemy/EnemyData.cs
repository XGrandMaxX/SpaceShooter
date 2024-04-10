using UnityEngine;

namespace Game.Scripts.ScriptableObjects.Enemy
{
    public class EnemyData : ScriptableObject
    {
        [SerializeField] internal float _speed;
        [SerializeField] internal float _damage;
    }
}
