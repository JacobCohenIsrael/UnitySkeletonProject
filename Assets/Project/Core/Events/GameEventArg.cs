using System;
using System.Collections.Generic;
using UnityEngine;

namespace JCI.Core.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }
    
    public interface IGameEventArgListener
    {
        void OnEventRaised(object param);
    }


    [CreateAssetMenu(menuName = "JCI/GameEventArg", order = 100)]
    public class GameEventArg : ScriptableObject
    {
        /// <summary>
        /// list of subscribers to this event
        /// </summary>
        private readonly List<IGameEventArgListener> listeners = new List<IGameEventArgListener>();
        private readonly List<Action<object>> actions = new List<Action<object>>();

        /// <summary>
        /// raise our event
        /// we go backwards to ensure that callers do not cause race conditions
        /// </summary>
        public void Raise(object param)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(param);
            }
            for (int i = actions.Count - 1; i >= 0; i--)
            {
                actions[i].Invoke(param);
            }
        }
        
        
        /// <summary>
        /// subscribe a listener to this event, this will happen when the listener becomes enabled
        /// </summary>
        /// <param name="listener">the monobehaviour we are listening 'from'</param>
        public void RegisterListener(IGameEventArgListener listener)
        {
            if (listeners.Contains(listener))
            {
                Debug.LogWarning($"listener {listener} is already registered");
                return;
            }
            listeners.Add(listener);
        }

        /// <summary>
        /// remove a listener, this will happen when the listener object becomes disabled
        /// </summary>
        /// <param name="listener">the monobehaviour we are listening 'from'</param>
        public void UnregisterListener(IGameEventArgListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
            else
            {
                Debug.LogWarning($"listener {listener} is not registered and can't be removed");
            }
        }

        public void RegisterListener(Action<object> action)
        {
            if (actions.Contains(action))
            {
                Debug.LogWarning($"listener {action} is already registered");
                return;
            }
            actions.Add(action);
        }
        /// <summary>
        /// remove an action
        /// </summary>
        /// <param name="action">the action to remove</param>
        public void UnregisterListener(Action<object> action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
            else
            {
                Debug.LogWarning($"listener {action} is not registered and can't be removed");
            }
        }
    }
}