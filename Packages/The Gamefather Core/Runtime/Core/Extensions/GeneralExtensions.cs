using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JCI.Core.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsNullOrEmpty(this ICollection _this)
        {
            if (_this == null)
                return true;

            return _this.Count == 0;
        }

        public static bool IsNullOrEmpty(this string _this)
        {
            return string.IsNullOrEmpty(_this);
        }
        
        public static void SetActive(this List<GameObject> components, bool value)
        {
            if (components.IsNullOrEmpty())
                return;

            foreach (var component in components)
            {
                component.SetActive(value);
            }
        }
        
        public static void SetActive(this Component component, bool value)
        {
            component.gameObject.SetActive(value);
        }
    }
}