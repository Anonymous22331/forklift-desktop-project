using Input;
using UnityEngine;
using Zenject;

namespace Forklift
{
    public class ForkliftController : ITickable, IInitializable
    {
        private readonly ForkliftModel _model;
        private readonly ForkliftView _forkliftView;
        private readonly ForkliftUIView _uiView;
        private readonly IForkInputService _input;

        public ForkliftController(
            ForkliftModel model,
            ForkliftView movementView,
            ForkliftUIView ui,
            IForkInputService input)
        {
            _model = model;
            _forkliftView = movementView;
            _uiView = ui;
            _input = input;
        }

        public void Initialize()
        {
            SyncUI();
        }

        public void Tick()
        {
            HandleEngineToggle();
            HandleMovement();
            HandleFork();
            HandleFuel();

            SyncUI();
        }

        private void HandleEngineToggle()
        {
            if (_input.StartEnginePressed)
                _model.ToggleEngine();
        }

        private void HandleMovement()
        {
            if (!_model.IsEngineRunning)
                return;

            float speed = _model.UpdateSpeed(_input.Move, Time.deltaTime);
            float turn = _input.Turn * _model.TurnSpeed * _model.GetSpeedMultiplier();

            _forkliftView.ApplyMovement(speed);
            _forkliftView.ApplyTurn(turn);
        }

        private void HandleFork()
        {
            float delta = _input.Fork * _model.ForkSpeed * Time.deltaTime;
            _forkliftView.MoveFork(delta);
        }

        private void HandleFuel()
        {
            _model.ConsumeFuel(Time.deltaTime);
        }

        private void SyncUI()
        {
            _uiView.SetFuel(_model.FuelNormalized);
            _uiView.SetEngineState(_model.IsEngineRunning);
            _uiView.SetSpeed(_model.CurrentSpeed);
        }
    }
}