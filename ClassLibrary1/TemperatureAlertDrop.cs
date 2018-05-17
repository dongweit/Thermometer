using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public class TemperatureAlertDrop : TemperatureAlertBase, IAlert
    {
        public TemperatureAlertDrop(Threshold threshold, Action action) : base(threshold, action)
        { }

        public override void Check(double temperature)
        {
            var fluctuation = temperature - previousTemperature;
            previousTemperature = temperature;
            if (temperature > Threshold.Value)
            {
                if (!IsAlertOn)
                    return;

                if (Threshold.Value + Threshold.Fluctuation < temperature)
                    IsAlertOn = false;

                return;
            }

            if (IsAlertOn)
                return;

            if (fluctuation >= 0)
                return;

            IsAlertOn = true;

            Alert();



        }

    }
}
