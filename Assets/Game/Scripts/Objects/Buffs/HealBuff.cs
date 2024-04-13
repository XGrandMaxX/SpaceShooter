using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Objects.Buffs
{
    public sealed class HealBuff : Buff
    {
        private void Start()
        {
            DOTween.Sequence()
                .AppendInterval(LifeTime)
                .Append(transform.DOShakeScale(1, 1.2f).SetEase(Ease.OutBounce))
                .Append(transform.DOScale(Vector3.zero, 0.5f))
                .OnComplete(Die);
        }
    }
}
