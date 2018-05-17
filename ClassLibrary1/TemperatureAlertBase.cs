using System;
using System.Collections.Generic;
using System.Text;

namespace Thermometer
{

    /// <summary>
    /// Base class of a temperature alert
    /// </summary>
    public abstract class TemperatureAlertBase
    {
        /// <summary>
        /// Threshold property to allow caller set threhold
        /// </summary>
        public Threshold Threshold { get; set; }

        /// <summary>
        /// Flag to indicate if the alert reaches threshold value with fluctuation range.
        /// </summary>
        public bool IsAlertOn { get; protected set; }

        protected double previousTemperature;

        protected Action Alert;

        protected TemperatureAlertBase(Threshold threshold, Action alert)
        {
            Threshold = threshold ?? throw new ArgumentNullException(nameof(threshold));

            IsAlertOn = false;
            Alert = alert;
        }

        public void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Check(e.Temperature);
        }

        public virtual void Check(double tempererature)
        {
        }


    }
}
