using JCI.Attributes;
using UnityEngine;

public class TestAnimationSequence : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField, AnimatorTrigger] private string verticalTrigger, horizontalTrigger;
    [SerializeField, AnimatorState] private string verticalStateEnd, horizontalStateEnd;

    private void Start()
    {
        animator.TriggerAndWaitForState(horizontalTrigger, horizontalStateEnd).Then(() =>
        {
            animator.TriggerAndWaitForState(verticalTrigger, verticalStateEnd).Then(() =>
            {
                animator.ResetTriggers();
                Debug.Log("Done");
            });
        });
    }
}
