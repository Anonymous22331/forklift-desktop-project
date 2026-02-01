namespace Cargo
{
    public class CargoModel
    {
        public bool IsSpawned { get; private set; }
        public bool IsDelivered { get; private set; }

        public void MarkSpawned() => IsSpawned = true;
        public void MarkDelivered() => IsDelivered = true;
    }
}