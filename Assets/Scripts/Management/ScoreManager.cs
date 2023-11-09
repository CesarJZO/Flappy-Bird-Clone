using System;
using Core;
using Obstacles;
using Player;
using UnityEngine;

namespace Management
{
    public sealed class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public event Action<ulong> OnScoreUpdated;

        [SerializeField] private ulong score;

        public ulong Score => score;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ScoreTrigger.OnPipePassed += OnPipePassed;
        }

        private void OnDestroy()
        {
            ScoreTrigger.OnPipePassed -= OnPipePassed;
        }

        private void OnPipePassed()
        {
            if (GameManager.Instance.CurrentState is GameState.GameOver)
                return;

            score++;
            OnScoreUpdated?.Invoke(score);
        }
    }
}
