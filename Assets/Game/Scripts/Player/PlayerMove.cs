using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public sealed class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Vector2 _direction;

        private Rigidbody2D _rigidbody2D;

        private PlayerInputData _inputData;

        
        [Inject]
        private void Construct(PlayerInputData playerInputData, InputController inputController)
        {
            _inputData = playerInputData;
            _inputData._inputController = inputController;
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() 
            => _direction = _inputData.PlayerInput.Move.ReadValue<Vector2>();

        private void LateUpdate() 
            => _rigidbody2D.velocity = new Vector2(_direction.x, _direction.y) * _speed;
    }
}
