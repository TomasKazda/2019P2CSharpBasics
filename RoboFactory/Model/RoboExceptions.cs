using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFactory.Model
{
    class InstallationException : Exception
    {
        public InstallationException(string message) : base(message)
        {
        }

        public InstallationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    class BatteryExhaustedException : Exception
    {
        public BatteryExhaustedException(string message) : base(message)
        {
        }

        public BatteryExhaustedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
