using UnityEngine;
using Zenject;

namespace Cargo
{
    [RequireComponent(typeof(Collider))]
    public class CargoDeliveryZone : MonoBehaviour
    {
        private CargoDeliverySceneController _cargoSceneController;

        [Inject]
        public void Construct(CargoDeliverySceneController sceneController)
        {
            _cargoSceneController = sceneController;
        }

        private void Reset()
        {
            var col = GetComponent<Collider>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<CargoObject>(out _))
                return;
        
            _cargoSceneController.OnCargoDelivered();
        }
    }
}