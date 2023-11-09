using System;
using Core;
using Management;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [RequireComponent(typeof(PlayerInput))]
    public sealed class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public event Action OnJumpPerformed;
        public event Action OnPausePerformed;

        private PlayerInput _playerInput;

        private void Awake()
        {
            Instance = this;
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _playerInput.actions["Jump"].performed += OnJump;
            _playerInput.actions["Pause"].performed += OnPause;
        }

        private void OnDisable()
        {
            _playerInput.actions["Jump"].performed -= OnJump;
            _playerInput.actions["Pause"].performed -= OnPause;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            if (GameManager.Instance.CurrentState is not GameState.Playing)
                return;
            OnJumpPerformed?.Invoke();
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            OnPausePerformed?.Invoke();
        }
    }
}
