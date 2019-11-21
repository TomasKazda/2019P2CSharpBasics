using System;
using System.Collections.Generic;
using System.Text;
using RoboFactory.Interface;

namespace RoboFactory.Model
{
    public class BasicRoboticChasis : RoboPart, IEnergyUnit, IToolController, IExecutionUnit
    {
        public BasicRoboticChasis(string name = "Generic Chasis") : this(name, 20000, 200) { }
        public BasicRoboticChasis(string name, double battery, double consumption)
        {
            Name = name;
            MaxBatteryCapacity = battery;
            DeviceConsumption = consumption;
            RemainingBatteryCapacity = MaxBatteryCapacity;
        }
        public string Name { get; }
        protected RoboArm Arm { get; set; }
        public override double Consumption => base.Consumption + (Arm?.DeviceConsumption ?? 0);

        public double RemainingBatteryCapacity { get; private set; }
        public double MaxBatteryCapacity { get; private set; }
        public void ChargeUpTo(int percent)
        {
            percent = Math.Min(percent, 100);
            if (RemainingBatteryCapacity / MaxBatteryCapacity < percent / 100) RemainingBatteryCapacity = MaxBatteryCapacity * percent / 100;
        }

        public double GetHoursRemaining()
        {
            return RemainingBatteryCapacity / Consumption;
        }

        public void InstallTool(RoboArm tool)
        {
            if (Arm == null)
            {
                if (RemainingBatteryCapacity < 10) throw new BatteryExhaustedException("There is not enough power to connect the tool.");
                RemainingBatteryCapacity -= 10;
                Arm = tool;
            }
            else
                throw new InstallationException("Arm slot is not empty.");
        }

        public RoboArm RemoveTool()
        {
            var result = Arm;
            if (Arm != null)
            {
                if (RemainingBatteryCapacity < 10) throw new BatteryExhaustedException("There is not enough power to disconnect the tool.");
                RemainingBatteryCapacity -= 10;
                Arm = null;
            }
            return result;
        }

        public double Work(int hours)
        {
            if (Consumption * hours > RemainingBatteryCapacity) throw new BatteryExhaustedException("There is not enough power to complete this task.");
            RemainingBatteryCapacity -= Consumption * hours;
            return GetHoursRemaining();
        }

        public override string StatusMessage
        {
            get
            {
                return String.Format("Chasis {0} with {1} installed.\r\nRemaining battery capacity is {2}, which is enough for {3} hours of operation.",
                    Name,
                    Arm == null ? "nothing" : Arm.StatusMessage,
                    RemainingBatteryCapacity,
                    GetHoursRemaining()
                );
            }
        }
    }
}
