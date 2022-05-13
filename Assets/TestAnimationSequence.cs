using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationSequence : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string verticalTrigger, horizontalTrigger, verticalStateEnd, horizontalStateEnd;

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
