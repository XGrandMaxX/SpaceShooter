using System;

namespace Game.Scripts.Player
{
    public interface IPlayerCollision
    {
        event Action OnDied;
    }
}
