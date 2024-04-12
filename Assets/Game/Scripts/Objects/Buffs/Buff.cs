using UnityEngine;

namespace Game.Scripts.Objects.Buffs
{
    public abstract class Buff : MonoBehaviour
    {
        [SerializeField] protected internal byte BuffAmount = 1;
        [SerializeField] protected internal byte LifeTime = 10;

        protected virtual void Move() 
            => transform.position += Vector3.down * Time.deltaTime;

        public virtual void Spawn(Transform newSpawnPosition)
        {
            gameObject.SetActive(true);
            transform.position = newSpawnPosition.position;
        }
    }
}
