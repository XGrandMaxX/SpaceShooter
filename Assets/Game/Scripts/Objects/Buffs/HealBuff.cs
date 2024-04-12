namespace Game.Scripts.Objects.Buffs
{
    public sealed class HealBuff : Buff
    {
        private void Start() => Destroy(gameObject, LifeTime);

        private void FixedUpdate() => Move();
    }
}
