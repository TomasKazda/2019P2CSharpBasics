using System;
using RoboFactory.Interface;

namespace RoboFactory.Model
{
    public class DrillTool: RoboArm, IDrill
    {
        const double DrillCovGalacticConstant = 0.4;

        public DrillTool() : this(12, 1800) { }
        public DrillTool(int maxSize, int maxRotations)
        {
            AttachedToolType = ToolType.Drill;
            MaxSize = maxSize;
            MaxRotations = maxRotations;
        }

        public int MaxSize { get; protected set; }
        public int MaxRotations { get; protected set; }
        public int Size { get; protected set; }
        public int Rotations { get; protected set; }
        public int SetSize(int size) { Size = (size < MaxSize) ? size : MaxSize; return Size; }
        public int SetRotations(int rotations) { Rotations = (rotations < MaxRotations) ? rotations : MaxRotations; return Rotations; }

        public override double Consumption => base.Consumption + Rotations * Size * DrillCovGalacticConstant;
        public override string StatusMessage => $"Drill set up to {Size} mm and {Rotations} RPM";
    }
}
