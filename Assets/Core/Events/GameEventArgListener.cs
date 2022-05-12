using System;
using UnityEngine;

namespace JCI.Core.Events
{
    public abstract class GameEventArgListener<T> : MonoBehaviour, IGameEventArgListener
    {
        public GameEventArg Event;

        [SerializeField]
        private bool alwaysListen = false;

        private void Awake()
        {
            if (alwaysListen)
                Event.RegisterListener(this);
        }

        private void OnDestroy()
        {
            if (alwaysListen)
                Event.UnregisterListener(this);
        }

        private void OnEnable()
        {
            if (!alwaysListen)
                Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (!alwaysListen)
                Event.UnregisterListener(this);
        }

        public void OnEventRaised(object obj)
        {
            if (!(obj is T))
            {
                Debug.LogError(new Exception($"{this} event raised with wrong arg type - {obj.GetType()} instead of {typeof(T)}"));
                return;
            }
            
            Invoke(Cast(obj));
        }

        protected abstract void Invoke(T castedObj);
        
        private T Cast(object obj)
        {
            return (T) obj;
        }
    }
}