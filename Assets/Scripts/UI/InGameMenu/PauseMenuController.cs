using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.InGameMenu
{
    public class PauseMenuController : IInitializable, IDisposable
    {
        private enum ConfirmAction
        {
            None,
            ExitApplication,
            ReturnToMenu
        }

        private readonly PauseMenuModel _model;
        private readonly PauseMenuView _view;
        private readonly InputAction _pauseAction;

        private ConfirmAction _pendingAction;

        [Inject]
        public PauseMenuController(
            PauseMenuModel model,
            PauseMenuView view,
            InputActionAsset inputActions)
        {
            _model = model;
            _view = view;

            _pauseAction = inputActions
                .FindActionMap("UI")
                .FindAction("Pause");
        }

        public void Initialize()
        {
            _view.Initialize();
            _view.SetVisible(false);
            _view.HideConfirmation();

            _view.ContinueButton.clicked += Resume;
            _view.ToMenuButton.clicked += RequestReturnToMenu;
            _view.ExitButton.clicked += RequestExit;

            _view.ConfirmButton.clicked += Confirm;
            _view.CancelButton.clicked += CancelConfirm;

            _pauseAction.performed += OnPause;
            _pauseAction.Enable();
        }

        public void Dispose()
        {
            _pauseAction.performed -= OnPause;
            _pauseAction.Disable();
        }

        private void OnPause(InputAction.CallbackContext _)
        {
            _model.Toggle();
            _view.SetVisible(_model.IsPaused);

            if (!_model.IsPaused)
                _view.HideConfirmation();
        }

        private void Resume()
        {
            _model.Resume();
            _view.SetVisible(false);
            _view.HideConfirmation();
        }

        private void RequestReturnToMenu()
        {
            _pendingAction = ConfirmAction.ReturnToMenu;
            _view.ShowConfirmation("Вернуться в главное меню?");
        }

        private void RequestExit()
        {
            _pendingAction = ConfirmAction.ExitApplication;
            _view.ShowConfirmation("Выйти из игры?");
        }

        private void CancelConfirm()
        {
            _pendingAction = ConfirmAction.None;
            _view.HideConfirmation();
        }

        private void Confirm()
        {
            _view.HideConfirmation();
            _model.Resume();

            switch (_pendingAction)
            {
                case ConfirmAction.ReturnToMenu:
                    SceneManager.LoadScene("MenuScene");
                    break;

                case ConfirmAction.ExitApplication:
                    Application.Quit();
                    break;
            }

            _pendingAction = ConfirmAction.None;
        }
    }
}
