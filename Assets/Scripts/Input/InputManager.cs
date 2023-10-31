using System;
using UnityEngine;

namespace Input
{
    public sealed class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public event Action OnJumpPerformed;
        public event Action OnPausePerformed;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnJumpPerformed?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                OnPausePerformed?.Invoke();
            }
        }
    }
}
