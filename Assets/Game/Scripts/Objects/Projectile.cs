using System;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _projectileSpeed;
        [SerializeField] Rigidbody2D _rigidbody2D;

        public void Launch()
            => _rigidbody2D.velocity = Vector2.up * _projectileSpeed;
    }
}
