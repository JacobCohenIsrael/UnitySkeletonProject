using System.Collections;
using System.Collections.Generic;
using JCI.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace JCI.Core
{
    public class PerformAction : MonoBehaviour
    {
        public UnityEvent action;

        public UnityEventString stringAction;
        
        
        public void Perform()
        {
            action.Invoke();
        }

        public void PerformStringAction(string value)
        {
            stringAction.Invoke(value);
        }
    }
}

