using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemotingIPC {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		Interfaces.IMyControler counter = null;
		private void button2_Click(object sender, EventArgs e) {
			try {
				if (counter == null) {
					System.Runtime.Remoting.Channels.Ipc.IpcClientChannel ipcClient = new System.Runtime.Remoting.Channels.Ipc.IpcClientChannel();
					System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ipcClient, false);

					System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownClientType(typeof(Interfaces.IMyControler), "ipc://MyServicePort/MyServiceControl");

					counter = (Interfaces.IMyControler)Activator.GetObject(typeof(Interfaces.IMyControler), "ipc://MyServicePort/MyServiceControl");
				}
				int i = counter.DoFunction("get");
				MessageBox.Show("Response of Service: " + i.ToString());
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}
	}

}
