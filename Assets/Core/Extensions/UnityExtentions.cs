using UnityEngine;

namespace JCI.Extensions
{
    public static class UnityExtentions
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            return go.GetComponent<T>() ? go.GetComponent<T>() : go.AddComponent<T>();
        }
    }
}
