using System;
using System.Collections.Generic;
using UnityEngine;

namespace JCI.Core.Events
{
    [CreateAssetMenu(menuName = "JCI/GameEvent", order = 100)]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// list of subscribers to this event
        /// </summary>
        private readonly List<IGameEventListener> listeners = new List<IGameEventListener>();
        private readonly List<Action> actions = new List<Action>();

        /// <summary>
        /// raise our event
        /// we go backwards to ensure that callers do not cause race conditions
        /// </summary>
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                actions[i].Invoke();
            }
        }
        /// <summary>
        /// subscribe a listener to this event, this will happen when the listener becomes enabled
        /// </summary>
        /// <param name="listener">the monobehaviour we are listening 'from'</param>
        public void RegisterListener(IGameEventListener listener)
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
        public void UnregisterListener(IGameEventListener listener)
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

        public void RegisterListener(Action action)
        {
            if (actions.Contains(action))
            {
                Debug.LogWarning($"listener {action} is already registered");
                return;
            }
            actions.Add(action);
        }
        /// <summary>
        /// remove a listener, this will happen when the listener object becomes disabled
        /// </summary>
        /// <param name="listener">the monobehaviour we are listening 'from'</param>
        public void UnregisterListener(Action action)
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



