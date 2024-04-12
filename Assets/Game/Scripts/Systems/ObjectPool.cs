using System;
using System.Collections.Generic;

namespace Game.Scripts.Systems
{
    public sealed class ObjectPool<T>
    {
        #region fields
        
        internal Queue<T> _pool = new();
        private List<T> _active = new();

        private Func<T> _preloadFunc;
        private Action<T> _getAction;
        private Action<T> _returnAction;
        
        #endregion
        
        #region Constructor
        
        public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int poolSize)
        {
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
