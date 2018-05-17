using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public interface IThermometer
    {
        TemperatureUnit ThermometerUnit { get; set; }
        double Temperature { get; }
        void UpdateTemperature(double temperature);

    }

    public interface IAlertThermometer
    {
        ICollection<IAlert> Alerts { get; }
    }

}
