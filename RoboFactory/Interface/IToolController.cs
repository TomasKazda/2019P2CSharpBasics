using System;
using System.Collections.Generic;
using System.Text;
using RoboFactory.Model;

namespace RoboFactory.Interface
{
    public interface IToolController
    {
        void InstallTool(RoboArm tool);
        RoboArm RemoveTool();
    }
}
