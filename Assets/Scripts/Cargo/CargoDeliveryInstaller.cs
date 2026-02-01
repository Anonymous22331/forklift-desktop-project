using Zenject;

namespace Cargo
{
    public class CargoDeliveryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CargoModel>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<CargoController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<CargoDeliverySceneController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<CargoDeliverySceneController>()
                .FromResolve();
        }
    }
}