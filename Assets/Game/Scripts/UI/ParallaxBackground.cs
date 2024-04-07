using UnityEngine;

namespace Game.Scripts.UI
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float parallaxEffect = 0.5f;

        private Vector2 parallaxOffset;
        private Vector2 backgroundTargetPosition;
        private Vector2 newBackgroundTargetPosition;
        private Vector2 startPosition;
        private float startZ;

        private void Start()
        {
            startPosition = transform.position;
            startZ = transform.position.z;
        }

        private void Update() => Parallax();

        private void Parallax()
        {
            parallaxOffset = new Vector2(
                startPosition.x - _player.position.x, 
                startPosition.y - _player.position.y) * parallaxEffect;

            backgroundTargetPosition =
                new Vector2(
                    startPosition.x + parallaxOffset.x, 
                    startPosition.y + parallaxOffset.y);
            
            newBackgroundTargetPosition = new Vector3(
                backgroundTargetPosition.x, backgroundTargetPosition.y, 
                startZ);
            
            transform.position = newBackgroundTargetPosition;
        }
    }
}
