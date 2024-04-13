using UnityEngine;

namespace Game.Scripts.Objects.Buffs
{
    public abstract class Buff : MonoBehaviour
    {
        [SerializeField] protected internal byte BuffAmount = 1;
        [SerializeField] protected internal byte LifeTime = 10;
        
        
        private void FixedUpdate() => Move();
        protected virtual void Move() 
            => transform.position += Vector3.down * Time.deltaTime;
        protected virtual void Die() => Destroy(gameObject);
    }
}
