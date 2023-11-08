using System;
using Management;
using UnityEngine;

namespace Player
{
    public sealed class BirdAudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip jumpAudioClip;

        private void Start()
        {
            Bird.Instance.OnJump += OnBirdJump;
        }

        private void OnDestroy()
        {
            Bird.Instance.OnJump -= OnBirdJump;
        }

        private void OnBirdJump()
        {
            if (!AudioManager.Instance)
                return;

            AudioManager.Instance.Play(jumpAudioClip);
        }
    }
}
