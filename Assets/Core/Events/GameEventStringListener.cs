using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class GameEventStringListener : GameEventArgListener<string>
    {
        public UnityEventString Response;

        protected override void Invoke(string obj)
        {
            Response.Invoke(obj);
        }
    }
    
    [System.Serializable]
    public class UnityEventString : UnityEvent<string>
    {

    }
}