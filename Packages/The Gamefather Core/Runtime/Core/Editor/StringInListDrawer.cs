using System.Linq;
using JCI.Core.Extensions;
using JCI.Core.Inspector;
using UnityEngine;
using UnityEditor;

namespace RK.Core.Editor
{
    [CustomPropertyDrawer(typeof(StringInList))]
    public class StringInListDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var stringInList = attribute as StringInList;
            var list = stringInList.List.ToList();

            if (list.IsNullOrEmpty())
                return;

            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    list.Insert(0, "<UNDEFINED>");

                    int index = Mathf.Max(0, list.IndexOf(property.stringValue));

                    index = EditorGUI.Popup(position, property.displayName, index, list.ToArray());

                    if (index > 0)
                        property.stringValue = list[index];
                    else
                    {
                        property.stringValue = "";
                    }
                    break;
                case SerializedPropertyType.Integer:
                    property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, list.ToArray());
                    break;
                default:
                    base.OnGUI(position, property, label);
                    break;
            }                      
        }
    }

}