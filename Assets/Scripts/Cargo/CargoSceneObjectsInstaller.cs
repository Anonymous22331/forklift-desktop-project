using UnityEngine;
using Zenject;

namespace Cargo
{
    public class CargoSceneObjectsInstaller : MonoInstaller
    {
        [SerializeField] private CargoView _cargoView;
        [SerializeField] private CargoLocation _cargoLocation;

        public override void InstallBindings()
        {
            Container
                .Bind<CargoView>()
                .FromInstance(_cargoView)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<CargoLocation>()
                .FromInstance(_cargoLocation)
                .AsSingle()
                .NonLazy();
        }
    }
}