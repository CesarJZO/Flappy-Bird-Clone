using System;
using Core;
using Input;
using UnityEngine;

namespace Management
{
    public sealed class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance { get; private set; }

        public event Action OnPause;
        public event Action OnResume;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InputManager.Instance.OnPausePerformed += OnPausePerformed;
        }

        private void OnDestroy()
        {
            InputManager.Instance.OnPausePerformed -= OnPausePerformed;
            Time.timeScale = 1f;
        }

        private void OnPausePerformed()
        {
            TogglePause();
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            GameManager.Instance.CurrentState = GameState.Paused;
            OnPause?.Invoke();
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            GameManager.Instance.CurrentState = GameState.Playing;
            OnResume?.Invoke();
        }

        public void TogglePause()
        {
            GameState currentState = GameManager.Instance.CurrentState;

            if (currentState is GameState.GameOver)
                return;

            if (currentState is GameState.Playing)
                Pause();
            else if (currentState is GameState.Paused)
                Resume();
        }
    }
}
