using Game.Scripts.Objects.Buffs;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems
{
    public sealed class BuffFactory
    {
        private static Buff[] _buffs;
        
        private BuffFactory([Inject(Id = "Buffs")] Buff[] buffs)
        {
            _buffs = buffs;
            
            Debug.Log("BuffFactory successfully inject!");
        }
        
        public static GameObject CreateBuff(Transform spawn, bool chanceToCreate = false)
        {
            bool mayCreate = false;
            
            if (chanceToCreate)
            {
                int chanceToCreateBuff = Random.Range(0, 101);
                mayCreate = chanceToCreateBuff is > 0 and < 15;
            }

            if (chanceToCreate && !mayCreate)
                return null;
            
            Buff newBuff = GenerateRandomBuff();

            GameObject newObject = Object.Instantiate(
                newBuff.gameObject,
                spawn.position,
                Quaternion.identity);

            return newObject;
        }

        private static Buff GenerateRandomBuff() => _buffs[Random.Range(0, _buffs.Length)];
    }
}
