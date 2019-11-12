using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NFCWriter.Resources;
using Windows.Networking.Proximity;
using Windows.Storage.Streams;

namespace NFCWriter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ProximityDevice _proximityDevice;

        public MainPage()
        {
            InitializeComponent();
            InitializeProximityDevice();

            UriTextBox.Text = "freetunes:uri=http://MyURL&title=MySongTitle&artist=MyArtist";
        }

        private void InitializeProximityDevice()
        {

            //init NFC
            _proximityDevice = ProximityDevice.GetDefault();

            // if NFC isn't supported on device, show user and disable the write button
            if (_proximityDevice == null)
            {
                WriteToNFCButton.IsEnabled = false;
                MessageBox.Show("Failed to initialized NFC on this device, are you sure it has NFC support?");
            }

            //hook up NFC events so we can update status when an NFC device is in or out of range
            //these are only for UX; telling the user that device is there or not
            _proximityDevice.DeviceArrived += _proximityDevice_DeviceArrived;
            _proximityDevice.DeviceDeparted += _proximityDevice_DeviceDeparted;
        }

        void _proximityDevice_DeviceDeparted(ProximityDevice sender)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                StatusTextBlock.Text = "Device departed.";
            });
        }

        void _proximityDevice_DeviceArrived(ProximityDevice sender)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                StatusTextBlock.Text = "Device detected.";
            });
        }

        long _publishedUriId = -1;

        private void WriteToNFCButton_Click(object sender, RoutedEventArgs e)
        {
            // make sure the device exists and was initialized
            if (_proximityDevice == null)
                return;

            // cancel if it's currently publishing a message
            if (_publishedUriId != -1)
            {
                _proximityDevice.StopPublishingMessage(_publishedUriId);
            }
            
            //Encoding the URL we write (must be Utf16)
            var dataWriter = new DataWriter { UnicodeEncoding = UnicodeEncoding.Utf16LE };

            //Capacity of tags differs 
            dataWriter.WriteString(UriTextBox.Text);
            
            var dataBuffer = dataWriter.DetachBuffer();

            // write our data to the tag, handler will get called upon successful transmission
            _publishedUriId = _proximityDevice.PublishBinaryMessage("WindowsUri:WriteTag", dataBuffer, messageTransmittedHandler);

        }

        private void messageTransmittedHandler(ProximityDevice sender, long messageId)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                StatusTextBlock.Text = "NFC Tag Written!";
            });
        }
    }
}