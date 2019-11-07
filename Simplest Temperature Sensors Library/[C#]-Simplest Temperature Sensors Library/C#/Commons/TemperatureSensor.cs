using System;
using Microsoft.SPOT;

namespace TemperatureSensorsLibrary.Commons
{
    /// <summary>
    /// Base class for every temperature sensor
    /// </summary>
    public abstract class TemperatureSensor
    {
        /// <summary>
        /// Function reading temperature in desired format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public abstract double ReadTemperature(TemperatureFormat format);
    }
}
