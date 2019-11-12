using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using TemperatureSensorsLibrary.Commons;

namespace TemperatureSensorsLibrary.Sensors
{
    /// <summary>
    /// TMP102 I2C temperature sensor
    /// </summary>
    public class TMP102 : TemperatureSensor
    {
        /// <summary>
        /// default timeout
        /// </summary>
        private const int TIMEOUT = 10000;

        /// <summary>
        /// Temperature register address
        /// </summary>
        private const int TEMPERATURE_REG_ADDR = 0x00;

        /// <summary>
        /// I2C device class
        /// </summary>
        private I2CDevice i2cDevice;

        /// <summary>
        /// Reading temperature in desired format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public override double ReadTemperature(TemperatureFormat format)
        {
            I2CDevice.I2CTransaction[] i2cTx = new I2CDevice.I2CTransaction[2];
            byte[] register = new byte[1];
            byte[] data = new byte[2];

            register[0] = TEMPERATURE_REG_ADDR;
            i2cTx[0] = I2CDevice.CreateWriteTransaction(register);
            i2cTx[1] = I2CDevice.CreateReadTransaction(data);

            int result = i2cDevice.Execute(i2cTx, TIMEOUT);

            //converting 12-bit temperature to double
            int rawTemperature = (data[0] << 4) | (data[1] >> 4);

            double temperature = 0;
            if (register.Length + data.Length == result)
            {
                if ((rawTemperature & 0x0800) > 0)
                {
                    rawTemperature = (rawTemperature ^ 0xffff) + 1;
                    temperature = -1;
                }
                temperature *= rawTemperature * 0.0625f;
            }
            return temperature + ((format == TemperatureFormat.KELVIN) ? 273.15 : 0.0); 
        }

        /// <summary>
        /// Class initialization
        /// </summary>
        /// <param name="address">device address</param>
        /// <param name="clockRateHz">clock rate [Hz]</param>
        public TMP102(ushort address = 72, int clockRateHz = 100)
        {
            I2CDevice.Configuration config = new I2CDevice.Configuration(address, clockRateHz);
            i2cDevice = new I2CDevice(config);
        }
    }
}
