using System.Reflection;
using JCI.Attributes;
using UnityEditor;
using UnityEngine;

namespace JCI.Editor
{
    [CustomEditor(typeof(Object), true)]
    public class ButtonAttributeDrawer : UnityEditor.Editor
    {
        private MethodInfo[] buttonMethods;

        private void OnEnable()
        {
            buttonMethods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var method in buttonMethods)
            {
                var buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttribute != null)
                {
                    if (GUILayout.Button(buttonAttribute.buttonName))
                    {
                        foreach (var obj in targets)
                        {
                            if (obj is MonoBehaviour monoBehaviour)
                            {
                                method.Invoke(monoBehaviour, null);
                            }
                            else if (obj is ScriptableObject scriptableObject)
                            {
                                method.Invoke(scriptableObject, null);
                            }
                        }
                    }
                }
            }
        }
    }
}