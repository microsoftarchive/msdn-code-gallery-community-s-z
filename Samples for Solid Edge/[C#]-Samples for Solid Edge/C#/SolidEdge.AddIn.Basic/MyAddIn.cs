using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SolidEdge.AddIn.Basic
{
    [Guid("5F47DA3A-B1CF-4B80-9038-C7823CD102E6")] // Must be unique!
    [ProgId("SolidEdge.AddIn.Basic")] // Must be unique!
    [ComVisible(true)]
    [AddInInfo("CodePlex Basic Addin", "Solid Edge Addin in .NET 4.0.")]
    [AddInEnvironmentCategory(CategoryIDs.CATID_SEApplication)]
    [AddInEnvironmentCategory(CategoryIDs.CATID_SEAllDocumentEnvrionments)]
    [AddInAutoConnect(true)]
    public class MyAddIn
        : SolidEdgeFramework.ISolidEdgeAddIn, SolidEdgeFramework.ISEAddInEvents, SolidEdgeFramework.ISEApplicationEvents
    {
        private SolidEdgeFramework.Application _application;
        private SolidEdgeFramework.ISEAddInEx _addInEx;
        private Dictionary<IConnectionPoint, int> _connectionPointDictionary = new Dictionary<IConnectionPoint, int>();

        #region SolidEdgeFramework.ISolidEdgeAddIn

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnConnection().
        /// </summary>
        public void OnConnection(object Application, SolidEdgeFramework.SeConnectMode ConnectMode, SolidEdgeFramework.AddIn AddInInstance)
        {
            _application = (SolidEdgeFramework.Application)Application;
            _addInEx = (SolidEdgeFramework.ISEAddInEx)AddInInstance;

            HookEvents(_addInEx, typeof(SolidEdgeFramework.ISEAddInEvents).GUID);
            HookEvents(_application, typeof(SolidEdgeFramework.ISEApplicationEvents).GUID);

            switch (ConnectMode)
            {
                case SolidEdgeFramework.SeConnectMode.seConnectAtStartup:
                    break;
                case SolidEdgeFramework.SeConnectMode.seConnectByUser:
                    break;
                case SolidEdgeFramework.SeConnectMode.seConnectExternally:
                    break;
            }
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnConnectToEnvironment().
        /// </summary>
        public void OnConnectToEnvironment(string EnvCatID, object pEnvironmentDispatch, bool bFirstTime)
        {
            Guid envGuid = new Guid(EnvCatID);
            SolidEdgeFramework.Environment environment = (SolidEdgeFramework.Environment)pEnvironmentDispatch;

            // Demonstrate working with CategoryIDs.
            if (envGuid.Equals(CategoryIDs.CATID_SEPart))
            {
            }
            else if (envGuid.Equals(CategoryIDs.CATID_SEDMPart))
            {
            }

            // Some things only need to be done during bFirstTime.
            if (bFirstTime)
            {
            }

        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnDisconnection().
        /// </summary>
        public void OnDisconnection(SolidEdgeFramework.SeDisconnectMode DisconnectMode)
        {
            switch (DisconnectMode)
            {
                case SolidEdgeFramework.SeDisconnectMode.seDisconnectAtShutdown:
                    break;
                case SolidEdgeFramework.SeDisconnectMode.seDisconnectByUser:
                    break;
                case SolidEdgeFramework.SeDisconnectMode.seDisconnectExternally:
                    break;
            }

            // Unhook all events.
            UnhookAllEvents();
        }

        #endregion

        #region SolidEdgeFramework.ISEAddInEvents

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommand event.
        /// </summary>
        public void OnCommand(int CommandID)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommandHelp event.
        /// </summary>
        public void OnCommandHelp(int hFrameWnd, int HelpCommandID, int CommandID)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommandUpdateUI event.
        /// </summary>
        public void OnCommandUpdateUI(int CommandID, ref int CommandFlags, out string MenuItemText, ref int BitmapID)
        {
            MenuItemText = String.Empty;
        }

        #endregion

        #region SolidEdgeFramework.ISEApplicationEvents

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterActiveDocumentChange event.
        /// </summary>
        public void AfterActiveDocumentChange(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterCommandRun event.
        /// </summary>
        public void AfterCommandRun(int theCommandID)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentOpen event.
        /// </summary>
        public void AfterDocumentOpen(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentPrint event.
        /// </summary>
        public void AfterDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentSave event.
        /// </summary>
        public void AfterDocumentSave(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterEnvironmentActivate event.
        /// </summary>
        public void AfterEnvironmentActivate(object theEnvironment)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterNewDocumentOpen event.
        /// </summary>
        public void AfterNewDocumentOpen(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterNewWindow event.
        /// </summary>
        public void AfterNewWindow(object theWindow)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterWindowActivate event.
        /// </summary>
        public void AfterWindowActivate(object theWindow)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeCommandRun event.
        /// </summary>
        public void BeforeCommandRun(int theCommandID)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentClose event.
        /// </summary>
        public void BeforeDocumentClose(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentPrint event.
        /// </summary>
        public void BeforeDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentSave event.
        /// </summary>
        public void BeforeDocumentSave(object theDocument)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeEnvironmentDeactivate event.
        /// </summary>
        public void BeforeEnvironmentDeactivate(object theEnvironment)
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeQuit event.
        /// </summary>
        public void BeforeQuit()
        {
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeWindowDeactivate event.
        /// </summary>
        public void BeforeWindowDeactivate(object theWindow)
        {
        }

        #endregion

        #region IConnectionPoint helpers

        /// <summary>
        /// Attaches specified events to this object.
        /// </summary>
        private void HookEvents(object eventSource, Guid eventGuid)
        {
            IConnectionPointContainer container = null;
            IConnectionPoint connectionPoint = null;
            int cookie = 0;

            container = (IConnectionPointContainer)eventSource;
            container.FindConnectionPoint(eventGuid, out connectionPoint);

            if (connectionPoint != null)
            {
                connectionPoint.Advise(this, out cookie);
                _connectionPointDictionary.Add(connectionPoint, cookie);
            }
        }

        /// <summary>
        /// Detaches specified events from this object.
        /// </summary>
        private void UnhookAllEvents()
        {
            Dictionary<IConnectionPoint, int>.Enumerator enumerator = _connectionPointDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Key.Unadvise(enumerator.Current.Value);
            }

            _connectionPointDictionary.Clear();
        }

        #endregion

        #region regasm.exe

        /// <summary>
        /// Implementation of ComRegisterFunction.
        /// </summary>
        /// <remarks>
        /// This method gets called when regasm.exe is executed against the assembly.
        /// </remarks>
        [ComRegisterFunction]
        public static void Register(Type t)
        {
            var info = (AddInInfoAttribute)AddInInfoAttribute.GetCustomAttribute(t, typeof(AddInInfoAttribute));
            var environments = (AddInEnvironmentCategoryAttribute[])AddInEnvironmentCategoryAttribute.GetCustomAttributes(t, typeof(AddInEnvironmentCategoryAttribute));
            var autoConnect = (AddInAutoConnectAttribute)AddInAutoConnectAttribute.GetCustomAttribute(t, typeof(AddInAutoConnectAttribute));

            if (info == null) throw new System.Exception("Missing AddInInfoAttribute.");
            if ((environments == null) || (environments.Length == 0))
            {
                throw new System.Exception("Missing AddInEnvironmentCategoryAttribute.");
            }
            if (autoConnect == null) autoConnect = new AddInAutoConnectAttribute(true);

            string subkey = String.Format(@"CLSID\{0}", t.GUID.ToString("B"));
            using (RegistryKey baseKey = Registry.ClassesRoot.CreateSubKey(subkey))
            {
                subkey = String.Format(@"Implemented Categories\{0}", CategoryIDs.CATID_SolidEdgeAddIn);
                using (RegistryKey implementedCategoriesKey = baseKey.CreateSubKey(subkey))
                {
                }

                foreach (var environment in environments)
                {
                    subkey = String.Format(@"Environment Categories\{0}", environment.Guid.ToString("B"));
                    using (RegistryKey environmentCategoryKey = baseKey.CreateSubKey(subkey))
                    {
                    }
                }

                using (RegistryKey summaryKey = baseKey.CreateSubKey("Summary"))
                {
                    summaryKey.SetValue("409", info.Summary);
                }

                baseKey.SetValue("AutoConnect", autoConnect.AutoConnect ? 1 : 0);
                baseKey.SetValue("409", info.Title);
            }
        }

        /// <summary>
        /// Implementation of ComUnregisterFunction.
        /// </summary>
        /// <remarks>
        /// This method gets called when regasm.exe is executed against the assembly.
        /// </remarks>
        [ComUnregisterFunction]
        public static void Unregister(Type t)
        {
            string subkey = String.Format(@"CLSID\{0}", t.GUID.ToString("B"));
            Registry.ClassesRoot.DeleteSubKeyTree(subkey, false);
        }

        #endregion

        #region Properties

        public SolidEdgeFramework.Application Application { get { return _application; } }
        public SolidEdgeFramework.ISEAddInEx AddIn { get { return _addInEx; } }

        #endregion
    }
}
