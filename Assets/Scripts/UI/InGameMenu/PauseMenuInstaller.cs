using UnityEngine;
using Zenject;

namespace UI.InGameMenu
{
    public class PauseMenuInstaller : MonoInstaller
    {
        [SerializeField] private PauseMenuView _pauseMenuView;

        public override void InstallBindings()
        {
            Container
                .Bind<PauseMenuModel>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PauseMenuView>()
                .FromInstance(_pauseMenuView)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<PauseMenuController>()
                .AsSingle()
                .NonLazy();
        }
    }
}