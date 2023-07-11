using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JCI.Core.Events
{
    public class PerformDestroy : MonoBehaviour
    {
        public GameObject target;

        public void DestroyTarget()
        {
            Destroy(target);
        }

    }
}

