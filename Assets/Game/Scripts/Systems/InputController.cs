using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Systems
{
    public sealed class InputController
    {
        private InputActions _inputActions;
        public InputActions InputActions => _inputActions;
        
        private readonly Dictionary<object, Action> _subscribers = new(5);
        
        public InputController()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
            
            Debug.Log("InputController successfully initialize!");
        }
        
        public void Subscribe(
            object subscriber, 
            Action action, 
            InputAction inputAction)
        {
            if (!_subscribers.TryAdd(subscriber, action)) 
                return;
            
            inputAction.performed += context => action();
        }
        public void Subscribe(
            object subscriber, 
            Action performedAction,
            Action canceledAction,
            InputAction inputAction)
        {
            if (!_subscribers.TryAdd(subscriber, performedAction)) 
                return;
            
            inputAction.performed += context => performedAction();
            inputAction.canceled += context => canceledAction();
        }

        public void UnSubscribe(object subscriber)
        {
            if (!_subscribers.ContainsKey(subscriber))
                return;
            
            _subscribers.Remove(subscriber);
        }
    }
}
