using System;
using Management;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            ScoreManager.Instance.OnScoreUpdated += OnScoreUpdated;
        }

        private void OnDestroy()
        {
            ScoreManager.Instance.OnScoreUpdated -= OnScoreUpdated;
        }

        private void OnScoreUpdated(ulong currentScore)
        {
            _scoreText.text = currentScore.ToString("D2");
        }
    }
}
