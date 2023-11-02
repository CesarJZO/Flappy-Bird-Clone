using System;

namespace Management
{
    public static class SceneManager
    {
        public static int CurrentSceneIndex => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        public static void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        public static void LoadScene(int sceneIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }

        public static bool TryLoadNextScene()
        {
            try
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(CurrentSceneIndex + 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ReloadCurrentScene()
        {
            LoadScene(CurrentSceneIndex);
        }
    }
}
