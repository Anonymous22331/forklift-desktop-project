using Zenject;

namespace Cargo
{
    public class CargoDeliverySceneController : IInitializable
    {
        private readonly CargoController _cargoController;
        private readonly CargoLocation _cargoLocation;

        [Inject]
        public CargoDeliverySceneController(CargoController cargoController, CargoLocation cargoLocation)
        {
            _cargoController = cargoController;
            _cargoLocation = cargoLocation;
        }

        public void Initialize()
        {
            _cargoController.Spawn(_cargoLocation.SpawnPosition);
        }

        public void OnCargoDelivered()
        {
            _cargoController.Deliver();
        }
    }
}