using UnityEngine;

namespace Game.Scripts.Enemies.ScriptableObjects
{
    [CreateAssetMenu(menuName = "NewEnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] internal byte Health;
        
        [SerializeField] private int _score;
        public int Score => _score;
        
        [Min(0.1f), SerializeField] internal float _moveDuration;
        public float MoveDuration => _moveDuration;

        
        public void Initialize(byte health, float moveDuration)
        {
            Health = health;
            _moveDuration = moveDuration;
        }

    }
}
