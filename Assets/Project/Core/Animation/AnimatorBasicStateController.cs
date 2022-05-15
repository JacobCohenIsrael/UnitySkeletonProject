using System;
using JCI.Core;
using JCI.Core.Animations;
using RSG;
using UnityEngine;

namespace JCI.Core.Animation
{
    public class AnimatorBasicStateController : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField, AnimatorTrigger(nameof(animator))] private string triggerEnter = "enter", triggerExit = "exit", triggerIdle = "idle";
        [SerializeField, AnimatorState(nameof(animator))] private string endState = "End State";
        
        public bool Visible
        {
            get;
            private set;
        }
        
        private bool ValidateAnimator(Animator animator)
        {
            return animator != null;
        }

        private void Awake()
        {
            Visible = false;
        }

        public IPromise Enter(bool waitForEndState = false)
        {
            gameObject.SetActive(true);
            Visible = true;

            if (animator == null)
                return Promise.Resolved();

            if (waitForEndState)
            {
                return animator.TriggerAndWaitForState(triggerEnter, endState);    
            }
            
            animator.SetTrigger(triggerEnter);
            return Promise.Resolved();
        }

        public void Exit()
        {
            if (animator != null)
                animator.SetTrigger(triggerExit);
            Visible = false;
        }

        public void Idle()
        {
            if (animator != null)
                animator.SetTrigger(triggerIdle);
            Visible = true;
        }
    }
}