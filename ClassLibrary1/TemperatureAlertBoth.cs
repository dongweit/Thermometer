using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public class TemperatureAlertBoth: TemperatureAlertBase, IAlert
    {
        public TemperatureAlertBoth(Threshold threshold, Action action)
            : base(threshold, action) { }

        public override void Check(double temperature)
        {
            if (temperature != Threshold.Value)
            {
                if (!IsAlertOn) return;

                if (Threshold.Value - Threshold.Fluctuation > temperature)
                    IsAlertOn = false;

                if (Threshold.Value + Threshold.Fluctuation < temperature)
                    IsAlertOn = false;
                return;
            }

            if (IsAlertOn)
                return;

            IsAlertOn = true;
            Alert();
        }
    }
}
