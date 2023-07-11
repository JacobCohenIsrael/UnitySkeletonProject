using System;
using UnityEngine;

namespace JCI.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string buttonName;

        public ButtonAttribute(string buttonName)
        {
            this.buttonName = buttonName;
        }
    }
}
