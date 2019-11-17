using System;
using System.Collections.Generic;
using System.Text;
using RoboFactory.Interface;

namespace RoboFactory.Model
{
    public class RoboArm: RoboPart, IRoboTools
    {
        const double ArmWithoutToolConsumption = 1000;

        protected RoboArm(): this(ArmWithoutToolConsumption) { }
        protected RoboArm(double noLoadConsumption)
        {
            DeviceConsumption = noLoadConsumption;
        }

        public ToolType AttachedToolType { get; protected set; } = ToolType.Custom;
        public override string StatusMessage => "Robotic Arm Mk1";
        public override double DeviceConsumption { get; protected set; }
    }
}
