using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{
    public class AlertThermometer : Thermometer, IAlertThermometer
    {
        public ICollection<IAlert> Alerts { get; }
        private event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        protected AlertThermometer() { }

        public AlertThermometer(TemperatureUnit unit,  ICollection<IAlert> alerts):base(unit)
        {

            foreach (var alert in alerts)
            {
                alert.Threshold.Value = alert.Threshold.Unit == unit ? alert.Threshold.Value: Converter.Convert(alert.Threshold.Value, alert.Threshold.Unit, unit);
                alert.Threshold.Fluctuation = alert.Threshold.Unit==unit?alert.Threshold.Fluctuation:  Converter.Convert(alert.Threshold.Fluctuation, alert.Threshold.Unit, unit);

                TemperatureChanged += alert.HandleTemperatureChanged;
            }
            Alerts = alerts;
        }

        public override void UpdateTemperature(double temperature)
        {
            base.UpdateTemperature(temperature);
            TemperatureChanged?.Invoke(null, new TemperatureChangedEventArgs(Temperature));
        }

    }
}
