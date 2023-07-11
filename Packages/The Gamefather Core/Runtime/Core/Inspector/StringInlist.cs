using System;
using JCI.Core.Extensions;
using JCI.Core.Utils;
using UnityEngine;

namespace JCI.Core.Inspector
{
    public class StringInList : PropertyAttribute
    {
        public delegate string[] GetStringList();

        public StringInList(string[] list)
        {
            List = list;
        }

        public StringInList(Type type, string methodName)
        {
            var method = type.GetMethod(methodName);
            if (method != null)
            {
                List = method.Invoke(null, null) as string[];
            }
            else
            {
                Debug.LogError(new Exception("NO SUCH METHOD " + methodName + " FOR " + type));
            }
        }


        public StringInList(Type type)
        {
            InitFromType(type);
        }

        private void InitFromType(Type type)
        {
            List = type.GetConstFields();

            if (List.IsNullOrEmpty())
            {
                Debug.LogError($"StringInList: can't find any const fields for type {type}");
                return;
            }
 
        }

        public StringInList(string typeName)
        {
            InitFromType(Type.GetType(typeName));
        }

        public string[] List
        {
            get;
            private set;
        }
    }

}