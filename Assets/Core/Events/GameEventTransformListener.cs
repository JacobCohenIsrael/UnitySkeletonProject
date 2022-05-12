using UnityEngine;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventTransformListener : GameEventArgListener<Transform>
    {
        public UnityEventTransform Response;

        protected override void Invoke(Transform obj)
        {
            Response.Invoke(obj);
        }
    }
    
    [System.Serializable]
    public class UnityEventTransform : UnityEvent<Transform>
    {
        
    }
}