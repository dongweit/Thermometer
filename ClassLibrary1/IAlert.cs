using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public interface IAlert
    {
        Threshold Threshold { get; set; }
        void Check(double tempererature);
        void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);
    }

}
