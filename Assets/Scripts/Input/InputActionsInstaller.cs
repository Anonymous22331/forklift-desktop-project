using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public class InputActionsInstaller : MonoInstaller
    {
        [SerializeField] private InputActionAsset _inputActions;

        public override void InstallBindings()
        {
            Container
                .Bind<InputActionAsset>()
                .FromInstance(_inputActions)
                .AsSingle()
                .NonLazy();
        }
    }
}