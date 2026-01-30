public class MainMenuModel
{
    public bool ExitConfirmationVisible { get; private set; }

    public void ShowExitConfirmation() => ExitConfirmationVisible = true;
    public void HideExitConfirmation() => ExitConfirmationVisible = false;
}