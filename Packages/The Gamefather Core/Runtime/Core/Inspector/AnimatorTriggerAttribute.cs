using UnityEngine;

namespace JCI.Core.Inspector
{
    public class  AnimatorTriggerAttribute : PropertyAttribute
    {
        public string animatorReferenceName;

        public AnimatorTriggerAttribute(string referenceName = "animator")
        {
            this.animatorReferenceName = referenceName;
        }
    }
}
