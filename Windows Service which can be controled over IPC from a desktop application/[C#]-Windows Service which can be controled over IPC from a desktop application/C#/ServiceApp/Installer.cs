using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections.Specialized;
using System.ServiceProcess;

namespace ServiceApp {
	/// <summary>
	/// This is a custom project installer.
	/// Applies a unique name to the servce using the /name switch
	/// Sets user name and password using the /user and /password switches
	/// Allows the use of a local account using the /account switch
	/// </summary>
	[RunInstaller(true)]
	public class MyWinServiceInstaller : Installer {
		private ServiceInstaller serviceInstaller;
		private ServiceProcessInstaller processInstaller;

		public MyWinServiceInstaller() {
			processInstaller = new ServiceProcessInstaller();
			serviceInstaller = new ServiceInstaller();

			// Set some defaults
			processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			serviceInstaller.StartType = ServiceStartMode.Automatic;
			serviceInstaller.ServiceName = "MyWinService";

			Installers.Add(serviceInstaller);
			Installers.Add(processInstaller);
		}

		#region Access parameters

		/// <summary>
		/// Return the value of the parameter in dicated by key
		/// </summary>
		/// <param name="key">Context parameter key</param>
		/// <returns>Context parameter specified by key</returns>
		public string GetContextParameter(string key) {
			string sValue = "";
			try {
				sValue = this.Context.Parameters[key].ToString();
			} catch {
				sValue = "";
			}

			return sValue;
		}

		#endregion

		/// <summary>
		/// This method is run before the install process.
		/// This method is overriden to set the following parameters:
		/// service name (/name switch)
		/// account type (/account switch)
		/// for a user account user name (/user switch)
		/// for a user account password (/password switch)
		/// Note that when using a user account, if the user name or password is not set,
		/// the installing user is prompted for the credentials to use.
		/// </summary>
		/// <param name="savedState"></param>
		protected override void OnBeforeInstall(IDictionary savedState) {
			base.OnBeforeInstall(savedState);

			// Decode the command line switches
		}

		/// <summary>
		/// Modify the registry to install the new service
		/// </summary>
		/// <param name="stateServer"></param>
		public override void Install(IDictionary stateServer) {
			base.Install(stateServer);
		}

		/// <summary>
		/// Uninstall based on the service name
		/// </summary>
		/// <param name="savedState"></param>
		protected override void OnBeforeUninstall(IDictionary savedState) {
			base.OnBeforeUninstall(savedState);
		}

		/// <summary>
		/// Modify the registry to remove the service
		/// </summary>
		/// <param name="stateServer"></param>
		public override void Uninstall(IDictionary stateServer) {
			base.Uninstall(stateServer);
		}
	}//end class
}//end namespace declaration
