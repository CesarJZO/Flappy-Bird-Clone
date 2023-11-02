using System;
using Core;
using UnityEngine;

namespace Management
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public event Action<GameState> OnStateChanged;

        [SerializeField] private GameState currentState;

        public GameState CurrentState
        {
            get => currentState;
            set
            {
                if (currentState == value)
                    return;

                currentState = value;
                OnStateChanged?.Invoke(currentState);
            }
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}
