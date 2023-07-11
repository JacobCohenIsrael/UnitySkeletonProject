using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventIntListener : GameEventArgListener<int>
    {
        public UnityEventInt Response;

        protected override void Invoke(int obj)
        {
            Response.Invoke(obj);
        }
    }
    
    [System.Serializable]
    public class UnityEventInt : UnityEvent<int>
    {
        
    }
}