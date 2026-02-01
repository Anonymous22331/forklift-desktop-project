using UnityEngine;
using Zenject;

namespace Cargo
{
    public class CargoController
    {
        private readonly CargoModel _model;
        private readonly CargoView _view;

        [Inject]
        public CargoController(CargoModel model, CargoView view)
        {
            _model = model;
            _view = view;
        }

        public void Spawn(Vector3 spawnPosition)
        {
            if (_model.IsSpawned)
                return;

            _view.Spawn(spawnPosition, 5f);
            _model.MarkSpawned();
        }

        public void Deliver()
        {
            if (_model.IsDelivered)
                return;

            _view.PlayDeliveryAnimation(5f);
            _model.MarkDelivered();
        }
    }
}