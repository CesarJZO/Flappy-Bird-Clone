using System;
using Management;
using Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class GameOverUI : MonoBehaviour, IToggleable
    {
        private const int MainMenuSceneIndex = 0;

        [SerializeField] private Button replayButton;
        [SerializeField] private Button exitButton;

        [SerializeField] private UnityEvent onShow;

        private void Start()
        {
            replayButton.onClick.AddListener(() => SceneManager.ReloadCurrentScene());
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(MainMenuSceneIndex));

            Bird.Instance.OnDie += OnBirdDie;
            Hide();
        }

        private void OnDestroy()
        {
            Bird.Instance.OnDie -= OnBirdDie;
        }

        private void OnBirdDie()
        {
            GameOverManager.Instance.GameOver();
            Show();
        }

        public void Show()
        {
            gameObject.SetActive(true);

            onShow?.Invoke();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
