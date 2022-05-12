using JCI.Core.Events;
using UnityEngine;

namespace JCI.Core.Animations
{
    public class AnimatorEvent : MonoBehaviour
    {
        public string eventId;
    
        public GameEventArg animationEvent;

        public void SendEvent()
        {
            animationEvent.Raise(eventId);
        }
    }
}
