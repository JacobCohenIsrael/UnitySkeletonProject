using System;
using JCI.Core.Events;
using UnityEngine;

namespace JCI.Core.Animations
{
    public class AnimationStateNotifier : StateMachineBehaviour
    {
        public static event System.Action<Animator, int> AnimationStateEnter = (a,i) => { };

        public GameEventArg stateEnterEvent;
        public GameEvent gameEvent;
        public string gameEventResourcePath;

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                gameEvent = Resources.Load<GameEvent>(gameEventResourcePath);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AnimationStateEnter(animator, stateInfo.shortNameHash);
            if (stateEnterEvent != null)
            {
                stateEnterEvent.Raise(new AnimationStateData
                    {
                        animator = animator,
                        stateInfo = stateInfo
                    }
                );
            }

            if (gameEvent != null)
            {
                gameEvent.Raise();
            }
        }
    }
}

