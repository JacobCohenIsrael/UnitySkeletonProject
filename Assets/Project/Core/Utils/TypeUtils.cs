using System;
using System.Linq;
using JCI.Core.Extensions;
using UnityEngine;

namespace JCI.Core.Utils
{   
    public static class TypeUtils
    {
        public static string[] GetConstFields(this Type type)
        {
            var fields = type.GetFields();

            if (fields.IsNullOrEmpty())
            {
                return new string[0];
            }

            try
            {
                return fields.Where(x => x.IsStatic && x.IsLiteral).Select(x => x.GetRawConstantValue().ToString()).ToArray();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                return new string[0];
            }
        }
        
        public static string[] GetMethodsNames(this Type type)
        {
            var methods = type.GetMethods();

            if (methods.IsNullOrEmpty())
            {
                return new string[0];
            }

            try
            {
                return methods.Where(x => x.IsStatic).Select(x => x.Name.ToString()).ToArray();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                return new string[0];
            }
        }
    }
}


