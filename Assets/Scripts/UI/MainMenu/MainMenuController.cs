using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenuController : IInitializable
    {
        private readonly MainMenuModel _model;
        private readonly MainMenuView _view;

        public MainMenuController(MainMenuModel model, MainMenuView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _view.StartClicked += OnStart;
            _view.ExitClicked += OnExit;
            _view.ExitConfirmed += OnExitConfirmed;
            _view.ExitCancelled += OnExitCancelled;
        }

        private void OnStart()
        {
            SceneManager.LoadScene("MainScene");
        }

        private void OnExit()
        {
            _model.ShowExitConfirmation();
            _view.ShowExitConfirmation(true);
        }

        private void OnExitConfirmed()
        {
            Application.Quit();
        }

        private void OnExitCancelled()
        {
            _model.HideExitConfirmation();
            _view.ShowExitConfirmation(false);
        }
    }
}