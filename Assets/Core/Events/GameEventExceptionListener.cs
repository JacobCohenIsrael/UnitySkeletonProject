using System;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventExceptionListener : GameEventArgListener<Exception>
    {
        public UnityEventException Response;

        protected override void Invoke(Exception obj)
        {
            Response.Invoke(obj);
        }
    }
    
    
    [System.Serializable]
    public class UnityEventException : UnityEvent<Exception>
    {

    }
}