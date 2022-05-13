using JCI.Core.Animations;
using JCI.Extensions;
using RSG;
using UnityEngine;

public static class AnimatorExtensions
{
    public static IPromise WaitForState(this Animator animator, string stateName, float minTimeToWait = 0f)
    {
        return animator.GetOrAddComponent<AnimatorListener>().WaitForState(animator, stateName, minTimeToWait);
    }

    public static IPromise TriggerAndWaitForState(this Animator animator, string trigger, string stateName)
    {
        animator.SetTrigger(trigger);
        return animator.GetOrAddComponent<AnimatorListener>().WaitForState(animator, stateName).Then(() =>
        {
            if (animator != null && animator.gameObject.activeInHierarchy)
                animator.ResetTrigger(trigger);
        });
    }

    public static IPromise TriggerAndWaitForStateChange(this Animator animator, string trigger)
    {
        animator.SetTrigger(trigger);
        return animator.GetOrAddComponent<AnimatorListener>().WaitForStateChange(animator).Then(() =>
        {
            if (animator != null && animator.gameObject.activeInHierarchy)
                animator.ResetTrigger(trigger);
        });
    }

    public static void ResetTriggers(this Animator animator, params string[] triggers)
    {
        foreach (var trigger in triggers)
        {
            animator.ResetTrigger(trigger);
        }
    }
}