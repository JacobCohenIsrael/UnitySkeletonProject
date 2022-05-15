using UnityEngine;

namespace JCI.Core.Models
{
    [CreateAssetMenu(menuName = "JCI/Model/CounterVar")]
    public class CounterVar : IntVar
    {
        public int minValue = 0;
        public int maxValue = 1000;

        public void Increase()
        {
            value++;

            if (value > maxValue)
                value = maxValue;
        }

        public void Decrease()
        {
            value--;

            if (value < 0)
                value = 0;
        }
    }
}