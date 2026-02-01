using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Forklift
{
    public class ForkliftInstaller : MonoInstaller
    {
        [Header("View")]
        [SerializeField] private ForkliftView _view;
        [SerializeField] private ForkliftUIView _uiView;

        [Header("Fuel Settings")]
        [SerializeField] private float _maxFuel = 100f;
        [SerializeField] private float _fuelConsumptionPerSecond = 3f;
        [Range(0f, 1f)] [SerializeField] private float _lowFuelThreshold = 0.5f;
        [SerializeField] private float _lowFuelSpeedMultiplier = 0.5f;

        [Header("Movement Settings")]
        [SerializeField] private float _maxMoveSpeed = 6f;
        [SerializeField] private float _acceleration = 4f;
        [SerializeField] private float _deceleration = 6f;
        [SerializeField] private float _turnSpeed = 90f;
        
        [Header("Fork Settings")]
        [SerializeField] private float _forkLiftSpeed = 1.5f;

        public override void InstallBindings()
        {
            Container.BindInstance(_view).AsSingle();

            Container.Bind<ForkliftModel>()
                .AsSingle()
                .WithArguments(new object[] {
                    _maxFuel,
                    _maxMoveSpeed,
                    _turnSpeed,
                    _forkLiftSpeed,
                    _acceleration,
                    _deceleration,
                    _fuelConsumptionPerSecond,
                    _lowFuelThreshold,
                    _lowFuelSpeedMultiplier
                });

            Container.Bind<ForkliftUIView>()
                .FromInstance(_uiView)
                .AsSingle();

            Container.BindInterfacesTo<ForkliftController>()
                .AsSingle()
                .NonLazy();
        }
    }
}