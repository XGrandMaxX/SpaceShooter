using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Systems
{
    public class ObjectPool<T>
    {
        #region fields
        
        private Queue<T> _pool = new();
        private List<T> _active = new(); 

        private readonly Func<T> _preloadFunc;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;
        
        #endregion
        
        #region Constructor

        public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int poolSize)
        {
            if (preloadFunc == null)
            {
                Debug.LogError("Preload function is null");
                return;
            }
            
            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;

            for (int i = 0; i < poolSize; i++)
                Return(preloadFunc());
        }
        
        #endregion

        #region public methods
        
        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
            _getAction(item);
            _active.Add(item);

            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _active.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (T item in _active.ToArray())
                Return(item);
        }
        
        #endregion
    }
}
