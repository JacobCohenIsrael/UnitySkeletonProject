using System;
using UnityEngine;


namespace JCI.Core.Models
{
	[CreateAssetMenu(menuName = "JCI/Model/IntVar")]
	public class IntVar : VarType<int>
	{
		public void SetAndSave(int value)
		{
			this.value = value;
		}

		public void Add(int amount, bool notify)
		{
			this.value += amount;
			if (notify)
				Notify();
		}

	}

}










