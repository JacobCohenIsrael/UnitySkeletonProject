using UnityEngine;

namespace JCI.Core
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