using System;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            playButton.onClick.AddListener(Play);
            // exitButton.onClick.AddListener(() => Application.Quit());
            exitButton.onClick.AddListener(Application.Quit);
        }

        private void Play()
        {
            SceneManager.TryLoadNextScene();
        }
    }
}
