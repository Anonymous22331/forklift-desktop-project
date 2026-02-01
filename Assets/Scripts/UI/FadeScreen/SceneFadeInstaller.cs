using UnityEngine;
using Zenject;

namespace UI.FadeScreen
{
    public class SceneFadeInstaller : MonoInstaller
    {
        [SerializeField] private FadeScreenView _fadeScreenView;
        public override void InstallBindings()
        {
            Container.Bind<FadeScreenView>()
                .FromInstance(_fadeScreenView)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<FadeScreenController>()
                .AsSingle();
        }
    }
}