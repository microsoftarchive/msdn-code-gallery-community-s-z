using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using TemperatureSensorsLibrary.Commons;

namespace TemperatureSensorsLibrary.Sensors
{
    /// <summary>
    /// class for DS18B20  one-wire temperature sensor
    /// </summary>
    public class DS18B20 : TemperatureSensor
    {
        /// <summary>
        /// One Wire protocol commands
        /// </summary>
        enum OneWireCommands : byte
        {
            SkipRom = 0xCC,
            MeasureTemperature = 0x44,
            MatchRom = 0x55,
            ReadRom = 0xBE
        }

        /// <summary>
        /// OneWire class
        /// </summary>
        private OneWire oneWire;

        /// <summary>
        /// OneWire device address
        /// </summary>
        private byte[] address;

        /// <summary>
        /// Reading temperature
        /// </summary>
        /// <param name="format"> desired format</param>
        /// <returns></returns>
        public override double ReadTemperature(TemperatureFormat format)
        {
            int rawTemperature = 0;
            //if tere is only one device
            if (address == null)
            {
                if (oneWire.TouchReset() > 0)
                {
                    oneWire.WriteByte((int)OneWireCommands.SkipRom);
                    oneWire.WriteByte((int)OneWireCommands.MeasureTemperature);

                    while (oneWire.ReadByte() == 0) ;

                    oneWire.TouchReset();

                    oneWire.WriteByte((int)OneWireCommands.SkipRom);
                    oneWire.WriteByte((int)OneWireCommands.ReadRom);

                    rawTemperature = (UInt16)((UInt16)oneWire.ReadByte() | (UInt16)(oneWire.ReadByte() << 8));
                }
                else
                {
                    throw new Exception("Device not found");
                }
            }
            //else if there is device address provided
            else
            {
                bool match = false;
                byte[] found = null;
                //find device with provided address
                var devices = oneWire.FindAllDevices();
                foreach (byte[] codes in devices)
                {
                    match = true;
                    for (int i = 0; i < codes.Length; i++)
                    {
                        if (codes[i] != address[i])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        found = codes;
                        break;
                    }
                }
                if (found == null)
                {
                    throw new Exception("Device with specified address not found");
                }
                else
                {
                    if (oneWire.TouchReset() > 0)
                    {
                        oneWire.WriteByte((int)OneWireCommands.MatchRom);
                        foreach(byte codePart in found)
                            oneWire.WriteByte((int)codePart);
                        oneWire.WriteByte((int)OneWireCommands.MeasureTemperature);

                        while (oneWire.ReadByte() == 0) ;

                        oneWire.WriteByte((int)OneWireCommands.MatchRom);
                        foreach (byte codePart in found)
                            oneWire.WriteByte((int)codePart);
                        oneWire.WriteByte((int)OneWireCommands.ReadRom);

                        rawTemperature = (UInt16)((UInt16)oneWire.ReadByte() | (UInt16)(oneWire.ReadByte() << 8));
                    }
                }
            }

            //conversion
            double result = 1;
            if ((rawTemperature & 0x8000) > 0)
            {
                rawTemperature = (rawTemperature ^ 0xffff) + 1;
                result = -1;
            }
            result *= (6 * rawTemperature + rawTemperature / 4) / 100;
            return result + ((format == TemperatureFormat.KELVIN) ? 273.15 : 0.0);
        }

        public DS18B20(OutputPort devicePort, byte[] addr = null)
        {
            oneWire = new OneWire(devicePort);
            address = addr;
        }
    }
}
