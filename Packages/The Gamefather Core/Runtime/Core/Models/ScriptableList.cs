using JCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JCI.Core.Models
{
    public interface IIdentifiable
    {
        string Id { get; }
    }

    public abstract class BaseScriptableList<T> : ScriptableObject, IValidatable
    {
        public List<T> items;
        
        public T this[int index] => items[index];

        public int Count => items.Count;
        
        public virtual bool IsValid()
        {
            return true;
        }
    }

    public abstract class ScriptableList<T> : BaseScriptableList<T> where T : IIdentifiable
    {
        public T this[string id] => items.FirstOrDefault(x => x.Id == id);
    }
}