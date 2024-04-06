using UnityEngine;

namespace Game.Scripts.Systems
{
    public class InputController
    {
        private InputActions _inputActions;
        public InputActions InputActions => _inputActions;
        
        public InputController()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
            
            Debug.Log("Successfully initialize!");
        }
    }
}
