using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class BackgroundMove : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed;
        
        private Transform _transform;
        private float _size;
        private float _targetPosition;
        private float _newPosition;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _size = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        private void Update() => Move();

        private void Move()
        {
            _targetPosition += _scrollSpeed * Time.deltaTime;
            _targetPosition = Mathf.Repeat(_targetPosition, _size);
            
            _transform.position = new Vector3(0, _targetPosition, 0);
        }
    }
}
