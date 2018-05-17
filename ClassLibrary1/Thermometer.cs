using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public class Thermometer: IThermometer
    {
        public TemperatureUnit ThermometerUnit { get; set; }
        public double Temperature { get; private set; }

        protected Thermometer() { }

        public Thermometer(TemperatureUnit unit)
        {
            ThermometerUnit = unit;
            Temperature = 0.0;
        }

        public virtual void UpdateTemperature(double temperature)
        {
            Temperature = ThermometerUnit == TemperatureUnit.C ? temperature: temperature;
        }

    }
}
