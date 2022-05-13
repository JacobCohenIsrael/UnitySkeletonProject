using System.Collections;
using System.Linq;
using JCI.Extensions;
using RSG;
using UnityEngine;

namespace JCI.Core.Animations
{
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

    public class AnimatorListener : MonoBehaviour
    {
        public IPromise WaitForStateChange(Animator animator)
        {
            var currentState = animator.GetCurrentAnimatorStateInfo(0);
            StopCoroutine(nameof(_WaitForStateChangeRoutine));
            var p = new Promise();
            StartCoroutine(_WaitForStateChangeRoutine());

            IEnumerator _WaitForStateChangeRoutine()
            {
                while (true)
                {
                    var state = animator.GetCurrentAnimatorStateInfo(0);
                    if (state.fullPathHash != currentState.fullPathHash)
                    {
                        p.Resolve();
                        yield break;
                    }
                    yield return null;
                }
            }

            return p;
        }

        public IPromise WaitForState(Animator animator, string stateName, float timeToWait = 0f)
        {
            StopCoroutine(nameof(_WaitForStateRoutine));
            var p = new Promise();   
            StartCoroutine(_WaitForStateRoutine());
            
            IEnumerator _WaitForStateRoutine()
            {
                if (timeToWait == 0)
                    yield return null;
                else
                    yield return new WaitForSeconds(timeToWait); // we wait an extra frame here so the animation state have time to change the state in case we transition from current state
                while (true)
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
                    {
                        p.Resolve();
                        yield break;
                    }
                    yield return null;
                }        
            }

            return p;
        }
    }
}