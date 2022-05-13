using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventBoolListener : GameEventArgListener<bool>
    {
        public UnityEventBool Response;
        
        protected override void Invoke(bool castedObj)
        {
            Response.Invoke(castedObj);    
        }
    }
    
    [System.Serializable]
    public class UnityEventBool : UnityEvent<bool>
    {
        
    }
}