using System;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Management
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public event Action<GameState> OnStateChanged;

        [SerializeField] private GameState currentState;
        [SerializeField] private UnityEvent<GameState> onStateChanged;

        public GameState CurrentState
        {
            get => currentState;
            set
            {
                if (currentState == value)
                    return;

                currentState = value;
                OnStateChanged?.Invoke(currentState);
                onStateChanged?.Invoke(currentState);
            }
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}
