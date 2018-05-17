using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public class TemperatureChangedEventArgs
    {
        public double Temperature { get; }

        public TemperatureChangedEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
}
