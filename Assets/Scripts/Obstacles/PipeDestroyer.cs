using System;
using UnityEngine;

namespace Obstacles
{
    public sealed class PipeDestroyer : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Pipe"))
                Destroy(other.gameObject);
        }
    }
}
