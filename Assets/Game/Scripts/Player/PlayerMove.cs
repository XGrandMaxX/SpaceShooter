using Game.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector2 _direction;

        private Rigidbody2D _rigidbody2D;
        private InputActions _inputActions;

        [Inject]
        private void Construct(InputController inputController)
        {
            _inputActions = inputController.InputActions;
            
            Initialize();
        }

        private void Initialize()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
