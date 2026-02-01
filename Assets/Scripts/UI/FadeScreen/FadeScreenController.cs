using Zenject;

namespace UI.FadeScreen
{
    public class FadeScreenController : IInitializable
    {
        private readonly FadeScreenView _view;

        [Inject]
        public FadeScreenController(FadeScreenView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            _view.Initialize();
            _view.FadeIn();
        }
    }
}