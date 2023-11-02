using System;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class PauseUI : MonoBehaviour, IToggleable
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            PauseManager pauseManager = PauseManager.Instance;

            pauseManager.OnPause += OnGamePaused;
            pauseManager.OnResume += OnGameResumed;

            resumeButton.onClick.AddListener(() => pauseManager.Resume());
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(0));

            Hide();
        }

        private void OnDestroy()
        {
            PauseManager pauseManager = PauseManager.Instance;

            pauseManager.OnPause -= OnGamePaused;
            pauseManager.OnResume -= OnGameResumed;
        }

        private void OnGamePaused()
        {
            Show();
        }

        private void OnGameResumed()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
