using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace JCI.Core.Models
{


	[CreateAssetMenu(menuName = "JCI/Model/IntRangeVar")]
	public class IntRangeVar : IntVar
	{
		public int min;
		public int max;


		public void Add(int amount)
		{
			value += amount;

			if (value > max) value = max;

			if (value < min) value = min;
		}

		public float Normalized
		{
			get { return value * 1.0f / max; }
		}

	}
}