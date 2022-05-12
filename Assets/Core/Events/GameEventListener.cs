using UnityEngine;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public UnityEvent Response;

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

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public void OnEventRaised(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}