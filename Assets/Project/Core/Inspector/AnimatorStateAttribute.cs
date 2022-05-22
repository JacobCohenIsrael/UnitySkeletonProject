using UnityEngine;

namespace JCI.Core.Inspector
{
    public class AnimatorStateAttribute : PropertyAttribute
    {
        public string animatorReferenceName;

        public AnimatorStateAttribute(string referenceName = "animator")
        {
            this.animatorReferenceName = referenceName;
        }
    }
}