using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using TemperatureSensorsLibrary.Commons;

namespace TemperatureSensorsLibrary.Sensors
{
    /// <summary>
    /// Class for analog temperature sensor LM35DZ
    /// </summary>
    public class LM35DZ : TemperatureSensor
    {
        /// <summary>
        /// ADC pin
        /// </summary>
        private AnalogInput temperatureInput;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="inputPin">input analog pin number</param>
        /// <param name="vref">ADC reference voltage</param>
        /// <param name="offset">ADC offset</param>
        /// <param name="precisionBits">ADC precision (in bits)</param>
        public LM35DZ(Cpu.AnalogChannel inputPin,double vref,double offset,
            int precisionBits)
        {
            temperatureInput = new AnalogInput(inputPin, vref, offset, precisionBits);
        }

        /// <summary>
        /// Reading temperature - 0 mV + 10mv\*C
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public override double ReadTemperature(TemperatureFormat format)
        {
            return temperatureInput.Read() * 100
                + ((format == TemperatureFormat.KELVIN) ? 273.15 : 0.0);
        }
    }
}
