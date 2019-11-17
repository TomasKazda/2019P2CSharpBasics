namespace RoboFactory.Interface
{
    public interface IEnergyUnit
    {
        double RemainingBatteryCapacity { get; }
        double MaxBatteryCapacity { get; }
        void ChargeUpTo(int percent);
        double GetHoursRemaining();
    }
}
