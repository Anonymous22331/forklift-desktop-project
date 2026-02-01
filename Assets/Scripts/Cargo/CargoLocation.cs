using UnityEngine;

namespace Cargo
{
    public class CargoLocation : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _deliveryPoint;

        public Vector3 SpawnPosition => _spawnPoint.position;
        public Vector3 DeliveryPosition => _deliveryPoint.position;
    }
}