using UnityEngine;
using Zenject;

public sealed class MenuSceneInstaller : MonoInstaller
{
    [SerializeField] private MainMenuView _menuView;

    public override void InstallBindings()
    {
        Container
            .Bind<MainMenuModel>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesTo<MainMenuController>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<MainMenuView>()
            .FromInstance(_menuView)
            .AsSingle()
            .NonLazy();
    }
}