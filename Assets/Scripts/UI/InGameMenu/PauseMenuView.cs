using UnityEngine;
using UnityEngine.UIElements;

namespace UI.InGameMenu
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;

        private VisualElement _root;
        private VisualElement _confirmOverlay;
        private Label _confirmTitle;

        private Button _continueButton;
        private Button _toMenuButton;
        private Button _exitButton;

        private Button _confirmButton;
        private Button _cancelButton;

        public void Initialize()
        {
            _root = _uiDocument.rootVisualElement;

            _confirmOverlay = _root.Q<VisualElement>("confirmOverlay");
            _confirmTitle = _root.Q<Label>("confirmTitle");

            _continueButton = _root.Q<Button>("continueButton");
            _toMenuButton = _root.Q<Button>("toMenuButton");
            _exitButton = _root.Q<Button>("exitButton");

            _confirmButton = _root.Q<Button>("confirmExitButton");
            _cancelButton = _root.Q<Button>("cancelExitButton");
        }

        public void SetVisible(bool visible)
        {
            _root.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
        }

        public void ShowConfirmation(string title)
        {
            _confirmTitle.text = title;
            _confirmOverlay.RemoveFromClassList("hiddenNotification");
        }

        public void HideConfirmation()
        {
            _confirmOverlay.AddToClassList("hiddenNotification");
        }

        public Button ContinueButton => _continueButton;
        public Button ToMenuButton => _toMenuButton;
        public Button ExitButton => _exitButton;

        public Button ConfirmButton => _confirmButton;
        public Button CancelButton => _cancelButton;
    }
}