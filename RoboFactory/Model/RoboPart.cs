using RoboFactory.Interface;

namespace RoboFactory.Model
{
    public abstract class RoboPart: IPowerConsumption
    {
        public virtual string StatusMessage => "General Robotic Part";

        public virtual double Consumption => DeviceConsumption;

        public double DeviceConsumption { get; protected set; }
    }
}
