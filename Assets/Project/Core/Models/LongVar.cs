using System;
using UnityEngine;

namespace JCI.Core.Models
{
    [CreateAssetMenu(menuName = "JCI/Model/LongVar")]
    public class LongVar : VarType<long>
    {
        public void Add(long amount, bool notify)
        {
            this.value += amount;
            if (notify)
                Notify();
        }
    }
}