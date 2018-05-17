using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public enum TemperatureUnit { C, F}


    public class Threshold
    {
        public string Name { get; set; }
        
        public double Value { get; set; }

        public double Fluctuation { get; set; }

        public TemperatureUnit Unit { get; set; }

    }
}
