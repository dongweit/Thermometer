using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TherometerConsole
{
    class Program
    {
        private static Thermometer.IThermometer thermometer;

        static void Main(string[] args)
        {
            var freezingThreshold = new Thermometer.Threshold() {
                Name="Freezing Point",
                Value=0.0,
                Fluctuation=0.5,
                Unit=Thermometer.TemperatureUnit.C,
            };

            var roomTemprature = new Thermometer.Threshold()
            {
                Name = "Room Temprature",
                Value = 25,
                Fluctuation = 0.5,
                Unit = Thermometer.TemperatureUnit.C
            };

            var boilingThreshold = new Thermometer.Threshold()
            {
                Name="Boiling Point",
                Value=100.0,
                Fluctuation=0.5,
                Unit=Thermometer.TemperatureUnit.C
            };

            var alerters = new List<Thermometer.IAlert>
            {
                new Thermometer.TemperatureAlertDrop(freezingThreshold,()=>Console.WriteLine("Freezing Alert")),
                new Thermometer.TemperatureAlertRaise(boilingThreshold,()=>Console.WriteLine("Boiling Alert")),
                new Thermometer.TemperatureAlertBoth(roomTemprature,()=>Console.WriteLine("Room Temperature")),
            };

            thermometer = new Thermometer.AlertThermometer(Thermometer.TemperatureUnit.C, alerters);


            foreach (var temperature in temperatures)
            {
                Console.WriteLine("new temp received {0}", temperature);
                try
                {
                    thermometer.UpdateTemperature(temperature);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(100);
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }


        private static List<double> temperatures = new List<double>
        {
            20.0, 24.6, 25.0, 25.4, 25.0, 50, 100, 60, 25.0, 0.0

        };
    }
}
