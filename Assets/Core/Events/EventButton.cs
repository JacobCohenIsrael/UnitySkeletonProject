using UnityEngine;
using UnityEngine.UI;

namespace JCI.Core.Events
{
    [RequireComponent(typeof(Button))]
    public class EventButton : MonoBehaviour
    {
        public GameEvent gameEvent;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                gameEvent.Raise();
            });
        }
    }
}