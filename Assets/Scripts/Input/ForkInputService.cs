using System;
using Zenject;

namespace Input
{
    public class ForkInputService : IForkInputService, IInitializable, IDisposable
    {
        private ForkliftInputActions _actions;

        public float Move => _actions.Gameplay.Move.ReadValue<float>();
        public float Turn => _actions.Gameplay.Turn.ReadValue<float>();
        public float Fork => _actions.Gameplay.ForkLifting.ReadValue<float>();

        public bool StartEnginePressed =>
            _actions.Gameplay.StartEngine.WasPressedThisFrame();

        public void Initialize()
        {
            _actions = new ForkliftInputActions();
            _actions.Enable();
        }

        public void Dispose()
        {
            _actions.Disable();
            _actions.Dispose();
        }
    }
}
