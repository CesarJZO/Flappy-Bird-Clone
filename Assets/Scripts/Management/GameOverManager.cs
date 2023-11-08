using Core;
using UnityEngine;

namespace Management
{
    public sealed class GameOverManager : MonoBehaviour
    {
        public static GameOverManager Instance { get; private set; }

        public void Awake()
        {
            Instance = this;
        }

        public void GameOver()
        {
            GameManager.Instance.CurrentState = GameState.GameOver;
        }
    }
}
