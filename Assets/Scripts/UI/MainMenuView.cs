using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuView : MonoBehaviour
{
    public event Action StartClicked;
    public event Action ExitClicked;
    public event Action ExitConfirmed;
    public event Action ExitCancelled;

    [SerializeField] private UIDocument _document;

    private VisualElement _exitOverlay;

    private void Awake()
    {
        var root = _document.rootVisualElement;

        root.Q<Button>("startButton").clicked += () => StartClicked?.Invoke();
        root.Q<Button>("exitButton").clicked += () => ExitClicked?.Invoke();
        root.Q<Button>("confirmExitButton").clicked += () => ExitConfirmed?.Invoke();
        root.Q<Button>("cancelExitButton").clicked += () => ExitCancelled?.Invoke();

        _exitOverlay = root.Q<VisualElement>("exitOverlay");
    }

    public void ShowExitConfirmation(bool visible)
    {
        _exitOverlay.EnableInClassList("hiddenNotification", !visible);
    }
}