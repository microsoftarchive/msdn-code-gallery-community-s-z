using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace NxtCar
{
    public class CarControl
    {
        private enum Wheel
        {
            Left = 0,
            Right = 1
        }

        private StreamSocket _socket = null;
        private DataWriter _dataWriter = null;

        private int _leftSpeed = 0;
        private int _rightSpeed = 0;


        //give him a socket
        public CarControl(StreamSocket socket)
        {
            _socket = socket;
            _dataWriter = new DataWriter(_socket.OutputStream);

        }

        public int LeftSpeed
        {
            get { return _leftSpeed; }
            set
            {
                _leftSpeed = value;

                if (_leftSpeed > 100)
                {
                    _leftSpeed = 100;
                }
                else if (_leftSpeed < -100)
                {
                    _leftSpeed = -100;
                }
            }
        }

        public int RightSpeed
        {
            get { return _rightSpeed; }
            set
            {
                _rightSpeed = value;

                if (_rightSpeed > 100)
                {
                    _rightSpeed = 100;
                }
                else if (_rightSpeed < -100)
                {
                    _rightSpeed = -100;
                }
            }
        }

        public async void MoveCar()
        {
            if (_socket == null || _dataWriter == null)
            {
                throw new InvalidOperationException("NxtCar not connected");
            }

            WriteWheelUpdate(_dataWriter, Wheel.Left);
            WriteWheelUpdate(_dataWriter, Wheel.Right);

            await _dataWriter.StoreAsync();
        }

        private void WriteWheelUpdate(DataWriter dataWriter, Wheel wheel)
        {
            if (_socket == null || _dataWriter == null)
            {
                throw new InvalidOperationException("NxtCar not connected");
            }

            // The SetOutputState message is 12 bytes long
            dataWriter.WriteByte(0x0C);     // Message length LSB
            dataWriter.WriteByte(0x00);     // Message length MSB

            dataWriter.WriteByte(0x80);     // Direct Command - no response required.
            dataWriter.WriteByte(0x04);     // SetOutputState command

            // Output Port.
            dataWriter.WriteByte((byte)wheel);

            // Power Set Point.
            dataWriter.WriteByte((byte)(wheel == Wheel.Left ? _leftSpeed : _rightSpeed));

            // Mode Byte.
            dataWriter.WriteByte(0x01);     // Motor On.

            // Regulation Mode.
            dataWriter.WriteByte(0x00);

            // Turn Ratio.
            dataWriter.WriteByte(0x00);

            // Run State.
            if ((wheel == Wheel.Left ? (_leftSpeed != 0) : (_rightSpeed != 0)))
            {
                dataWriter.WriteByte(0x20);
            }
            else
            {

                dataWriter.WriteByte(0x00);
            }

            // Tacho Limit.
            dataWriter.WriteUInt32(0x00);   // Run forever.
        }


        //tell him to stop
        public void Stop(Dispatcher dispatcher)
        {
            try
            {

                if (_socket != null)
                {
                    _socket.Dispose();
                    _socket = null;
                }
            }
            catch (Exception f)
            {
                dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(String.Format("Error closing socket: = {0}", f.Message));
                });
            }
        }

        public bool IsConnected
        {
            get
            {
                return (_socket != null && _dataWriter != null);
            }
        }

    }
}
