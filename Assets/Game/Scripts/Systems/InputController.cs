using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Systems
{
    public class InputController
    {
        private InputActions _inputActions;
        public InputActions InputActions => _inputActions;
        
        private Dictionary<object, Action> _subscribers = new(5);
        
        public InputController()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
            
            Debug.Log("InputController successfully initialize!");
        }
        
        public void Subscribe(object subscriber, Action action, InputAction inputAction)
        {
            if (!_subscribers.TryAdd(subscriber, action)) 
                return;
            
            inputAction.performed += context => action();
        }

        public void UnSubscribe(object subscriber)
        {
            if (!_subscribers.ContainsKey(subscriber))
                return;
            
            _subscribers.Remove(subscriber);
        }
    }
}
