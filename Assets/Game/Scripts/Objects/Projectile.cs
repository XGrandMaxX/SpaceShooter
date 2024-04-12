using UnityEngine;

namespace Game.Scripts.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] internal byte Damage;
        [SerializeField] internal byte LifeTime;
        [SerializeField] private float _speed;
        
        [SerializeField] Rigidbody2D _rigidbody2D;
        
        public virtual void Launch() => _rigidbody2D.velocity = Vector2.up * _speed;
    }
}
