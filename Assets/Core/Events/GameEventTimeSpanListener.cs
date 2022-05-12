using System;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventTimeSpanListener : GameEventArgListener<TimeSpan>
    {
        public UnityEventTimeSpan response;

        protected override void Invoke(TimeSpan obj)
        {
            response.Invoke(obj);
        }
    }
    
    [System.Serializable]
    public class UnityEventTimeSpan : UnityEvent<TimeSpan>
    {

    }
}