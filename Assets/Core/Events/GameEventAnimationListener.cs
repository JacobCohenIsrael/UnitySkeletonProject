using JCI.Core.Animations;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventAnimationListener : GameEventArgListener<AnimationStateData>
    {
        public UnityEventAnimation response;

        protected override void Invoke(AnimationStateData obj)
        {
            response.Invoke(obj);
        }
    }
    
    [System.Serializable]
    public class UnityEventAnimation : UnityEvent<AnimationStateData>
    {

    }
}