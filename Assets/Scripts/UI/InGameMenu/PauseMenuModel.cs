using UnityEngine;

namespace UI.InGameMenu
{
    public class PauseMenuModel
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }

        public void Toggle()
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }
}