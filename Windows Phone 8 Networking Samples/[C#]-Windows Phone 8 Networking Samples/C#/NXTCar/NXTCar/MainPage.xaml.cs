using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


using Windows.Networking.Proximity;
using Windows.System;
using Windows.Networking;
using Windows.Networking.Sockets;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Windows.Storage.Streams;
using System.Threading.Tasks;

namespace NxtCar
{
    public partial class MainPage : PhoneApplicationPage
    {
        Accelerometer acc;
        double z_threshold = -0.6;
        double y_threshold = 0;
        CarControl _cc;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            acc = new Accelerometer();
            acc.Stop();
        }

        private async void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            txtConnected.Text = "Connecting...";
            await SetupDeviceConn();

            acc.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            acc.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(Accelerometer_Motion);
            acc.Start();
            txtConnected.Text = "Connected!";


        }

        private async Task<bool> SetupDeviceConn()
        {
           //Connect to your paired NXTCar using BT + StreamSocket (over RFCOMM)
            PeerFinder.AlternateIdentities["Bluetooth:PAIRED"] = "";

            var devices = await PeerFinder.FindAllPeersAsync();
            if (devices.Count == 0)
            {
                MessageBox.Show("No bluetooth devices are paired, please pair your NXTCar");
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                return false;
            }
            
            PeerInformation peerInfo = devices.FirstOrDefault(c => c.DisplayName.Contains("NXT"));
            if (peerInfo == null)
            {
                MessageBox.Show("No paired NXTCar was found, please pair your NXTCar");
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                return false;
            }

            StreamSocket s = new StreamSocket();
            await s.ConnectAsync(peerInfo.HostName, "1");
            
            //This would ask winsock to do an SPP lookup for us; i.e. to resolve the port the 
            //device is listening on
            //await s.ConnectAsync(peerInfo.HostName, "{00001101-0000-1000-8000-00805F9B34FB}");

            _cc = new CarControl(s);
            return _cc.IsConnected;




        }

        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                acc.CurrentValueChanged -= new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(Accelerometer_Motion);
                acc.Stop();

                _cc.LeftSpeed = 0;
                _cc.RightSpeed = 0;
                _cc.MoveCar();
                _cc.Stop(Dispatcher);
                txtConnected.Text = "Not Connected";

            }
            catch(Exception f)
            {
                MessageBox.Show(String.Format("Error when stopping = {0}", f.Message));
            }
        }


        void Accelerometer_Motion(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Dispatcher.BeginInvoke(() => MoveCar(e.SensorReading));
        }

        private void MoveCar(AccelerometerReading r)
        {
            Vector3 acceleration = r.Acceleration;
            double z_limit = -0.4;
            double y_limit = -0.4;
            double leftAccel, rightAccel, leftTurn, rightTurn;

            leftAccel = (acceleration.Z - z_threshold) / (z_limit) * (150);
            rightAccel = (acceleration.Z - z_threshold) / (z_limit) * (150);

            leftTurn = (acceleration.Y - y_threshold) / (y_limit) * (100);
            rightTurn = (acceleration.Y - y_threshold) / (y_limit) * (-100);


            _cc.LeftSpeed = 1 * (int)(2 * leftAccel + leftTurn) / 3;
            _cc.RightSpeed = 1 * (int)(2 * rightAccel + rightTurn) / 3;
            _cc.MoveCar();


            LeftAccel.Text = "Left Acceleration" + leftAccel.ToString();
            RightAccel.Text = "Right Acceleration" + rightAccel.ToString();
            LeftTurn.Text = "Left Turn" + leftTurn.ToString();
            RightTurn.Text = "Right Turn" + rightTurn.ToString();
            AccelerometerData.Text = "X:" + acceleration.X.ToString("0.00") + " Y:" + acceleration.Y.ToString("0.00") + " Z:" + acceleration.Z.ToString("0.00");
            
        }

    }
}