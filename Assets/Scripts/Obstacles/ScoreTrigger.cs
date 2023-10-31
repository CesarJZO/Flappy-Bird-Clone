using System;
using UnityEngine;

namespace Obstacles
{
    public sealed class ScoreTrigger : MonoBehaviour
    {
        public static event Action OnPipePassed;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                OnPipePassed?.Invoke();
        }
    }
}
