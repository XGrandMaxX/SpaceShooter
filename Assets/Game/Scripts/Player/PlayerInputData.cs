using Game.Scripts.Systems;
using UnityEngine;

namespace Game.Scripts.Player
{
    [CreateAssetMenu(menuName = "PlayerData")]
    public class PlayerInputData : ScriptableObject
    {
       internal InputController _inputController;
       internal InputActions.PlayerActions PlayerInput
            => _inputController.InputActions.Player;
    }
}
