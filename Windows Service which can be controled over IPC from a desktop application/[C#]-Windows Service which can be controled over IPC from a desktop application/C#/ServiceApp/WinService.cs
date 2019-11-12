using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Microsoft.Win32;

namespace ServiceApp {
	public class MyWinService : System.ServiceProcess.ServiceBase {


		public MyWinService() {
			this.CanPauseAndContinue = false;

			this.ServiceName = "MyWinService";
		}

		System.Runtime.Remoting.Channels.Ipc.IpcServerChannel ipcServer = null;
		protected override void OnStart(string[] args) {
			base.OnStart(args);

			if (ipcServer == null) {
				//ipcServer = new System.Runtime.Remoting.Channels.Ipc.IpcServerChannel("MyServicePort");
				System.Collections.IDictionary properties =
new System.Collections.Hashtable();
				properties["name"] = "ipc";
				properties["authorizedGroup"] = "Everyone";
				properties["portName"] = "MyServicePort";
				ipcServer = new System.Runtime.Remoting.Channels.Ipc.IpcServerChannel(properties, null);
				System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ipcServer, false);
				System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(ControlClass), "MyServiceControl", System.Runtime.Remoting.WellKnownObjectMode.Singleton);
				Console.WriteLine(ipcServer.GetChannelUri());
			}
		}

		protected override void OnStop() {
			base.OnStop();
			if (ipcServer != null) System.Runtime.Remoting.Channels.ChannelServices.UnregisterChannel(ipcServer);
			ipcServer = null;
		}

		protected override void OnShutdown() {
			base.OnShutdown();
		}

		protected override void OnPause() {
			base.OnPause();
		}

		protected override void OnContinue() {
			base.OnContinue();
		}

	}

	[Serializable()]
	public class ControlClass : MarshalByRefObject, Interfaces.IMyControler {
		public int DoFunction(string command) {
			System.IO.File.WriteAllText("c:\\temp\\servicecommand.txt", command);
			return 1;
		}
	}
}
