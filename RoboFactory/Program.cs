using System;
using RoboFactory.Model;
using RoboFactory.Interface;
using static System.Console;

namespace RoboFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            RoboPart robot = new BasicRoboticChasis();

            IDrill drill = new DrillTool();
            drill.SetRotations(1000);
            drill.SetSize(10);

            if (robot is IToolController) (robot as IToolController).InstallTool((RoboArm)drill);
            
            WriteLine(robot.StatusMessage);

            try
            {
                (robot as IExecutionUnit).Work(17);
            } catch (Exception e)
            {
                WriteLine(e.Message);
            }
            

            WriteLine(robot.StatusMessage);
        }
    }
}
