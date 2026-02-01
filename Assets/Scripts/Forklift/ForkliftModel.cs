namespace Forklift
{
    public class ForkliftModel
    {
        public float Fuel { get; private set; }
        public bool IsEngineRunning { get; private set; }
    
        public float MaxFuel { get; }
        public float MaxMoveSpeed { get; }
        public float TurnSpeed { get; }
        public float ForkSpeed { get; }

        public float Acceleration { get; }
        public float Deceleration { get; }
        public float FuelConsumptionPerSecond { get; }

        public float LowFuelThreshold { get; }
        public float LowFuelSpeedMultiplier { get; }
    
        public float CurrentSpeed { get; private set; }

        public ForkliftModel(
            float maxFuel,
            float maxMoveSpeed,
            float turnSpeed,
            float forkSpeed,
            float acceleration,
            float deceleration,
            float fuelConsumptionPerSecond,
            float lowFuelThreshold,
            float lowFuelSpeedMultiplier)
        {
            MaxFuel = maxFuel;
            Fuel = maxFuel;

            MaxMoveSpeed = maxMoveSpeed;
            TurnSpeed = turnSpeed;
            ForkSpeed = forkSpeed;

            Acceleration = acceleration;
            Deceleration = deceleration;

            FuelConsumptionPerSecond = fuelConsumptionPerSecond;
            LowFuelThreshold = lowFuelThreshold;
            LowFuelSpeedMultiplier = lowFuelSpeedMultiplier;
        }

        public void ToggleEngine()
        {
            if (Fuel <= 0f)
                return;

            IsEngineRunning = !IsEngineRunning;
        }

        public float GetSpeedMultiplier()
        {
            return (Fuel / MaxFuel) <= LowFuelThreshold
                ? LowFuelSpeedMultiplier
                : 1f;
        }

        public float UpdateSpeed(float input, float deltaTime)
        {
            float targetSpeed = input * MaxMoveSpeed * GetSpeedMultiplier();

            float accel =
                System.Math.Abs(targetSpeed) > System.Math.Abs(CurrentSpeed)
                    ? Acceleration
                    : Deceleration;

            CurrentSpeed = UnityEngine.Mathf.MoveTowards(
                CurrentSpeed,
                targetSpeed,
                accel * deltaTime);

            return CurrentSpeed;
        }

        public void ConsumeFuel(float deltaTime)
        {
            if (!IsEngineRunning || Fuel <= 0f)
                return;

            Fuel -= FuelConsumptionPerSecond * deltaTime;
            if (Fuel < 0f)
                Fuel = 0f;

            if (Fuel == 0f)
                IsEngineRunning = false;
        }

        public float FuelNormalized =>
            MaxFuel <= 0f ? 0f : Fuel / MaxFuel;
    }
}
