using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public static class Converter
    {
        public static double Convert(double tempC, TemperatureUnit fromUnit, TemperatureUnit toUnit)
        {
            if (fromUnit == toUnit)
                return tempC;

            if(fromUnit==TemperatureUnit.C)
                return tempC * 1.8 + 32;

            if (fromUnit == TemperatureUnit.F)
                return (tempC - 32) * 5 / 9;

            return 0;
            
        }

    }
}
