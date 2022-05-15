using System;
using UnityEngine;

namespace JCI.Core.Models
{
	public class VarType<T> : ScriptableObject
	{
		public event Action<T> Updated = (t) => { };

		public T value;
		
		[SerializeField] private T defaultValue;
	

		public virtual bool IsValid()
		{
			if (value == null)
				return false;
			
			if (value is IValidatable validatable)
			{
				return validatable.IsValid();
			}
			
			return true;
		}
		
		public VarType()
		{

		}

		public VarType(T val)
		{
			value = val;
		}

		public static implicit operator T(VarType<T> s)
		{
			return s.value;
		}

		public void SetValue(T val)
		{
			value = val;
		}

		public void SetDefaultValue()
		{
			SetValue(defaultValue);
		}

		public void SetAndNotify(T val)
		{
			SetValue(val);
			Updated(value);
		}

		public void Notify()
		{
			Updated(value);
		}

		public override string ToString()
		{
			return value.ToString();
		}
	}
}