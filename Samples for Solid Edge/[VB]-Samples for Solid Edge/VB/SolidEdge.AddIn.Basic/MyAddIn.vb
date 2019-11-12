Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text

Namespace SolidEdge.AddIn.Basic
    <Guid("5F47DA3A-B1CF-4B80-9038-C7823CD102E6"), ProgId("SolidEdge.AddIn.Basic"), ComVisible(True), AddInInfo("CodePlex Basic Addin", "Solid Edge Addin in .NET 4.0."), AddInEnvironmentCategory(CategoryIDs.CATID_SEApplication), AddInEnvironmentCategory(CategoryIDs.CATID_SEAllDocumentEnvrionments), AddInAutoConnect(True)> _
    Public Class MyAddIn
        Implements SolidEdgeFramework.ISolidEdgeAddIn, SolidEdgeFramework.ISEAddInEvents, SolidEdgeFramework.ISEApplicationEvents

        Private _application As SolidEdgeFramework.Application
        Private _addInEx As SolidEdgeFramework.ISEAddInEx
        Private _connectionPointDictionary As New Dictionary(Of IConnectionPoint, Integer)()

#Region "SolidEdgeFramework.ISolidEdgeAddIn"

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnConnection().
        ''' </summary>
        Public Sub OnConnection(ByVal Application As Object, ByVal ConnectMode As SolidEdgeFramework.SeConnectMode, ByVal AddInInstance As SolidEdgeFramework.AddIn) Implements SolidEdgeFramework.ISolidEdgeAddIn.OnConnection
            _application = CType(Application, SolidEdgeFramework.Application)
            _addInEx = CType(AddInInstance, SolidEdgeFramework.ISEAddInEx)

            HookEvents(_addInEx, GetType(SolidEdgeFramework.ISEAddInEvents).GUID)
            HookEvents(_application, GetType(SolidEdgeFramework.ISEApplicationEvents).GUID)

            Select Case ConnectMode
                Case SolidEdgeFramework.SeConnectMode.seConnectAtStartup
                Case SolidEdgeFramework.SeConnectMode.seConnectByUser
                Case SolidEdgeFramework.SeConnectMode.seConnectExternally
            End Select
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnConnectToEnvironment().
        ''' </summary>
        Public Sub OnConnectToEnvironment(ByVal EnvCatID As String, ByVal pEnvironmentDispatch As Object, ByVal bFirstTime As Boolean) Implements SolidEdgeFramework.ISolidEdgeAddIn.OnConnectToEnvironment
            Dim envGuid As New Guid(EnvCatID)
            Dim environment As SolidEdgeFramework.Environment = CType(pEnvironmentDispatch, SolidEdgeFramework.Environment)

            ' Demonstrate working with CategoryIDs.
            If envGuid.Equals(CategoryIDs.CATID_SEPart) Then
            ElseIf envGuid.Equals(CategoryIDs.CATID_SEDMPart) Then
            End If

            ' Some things only need to be done during bFirstTime.
            If bFirstTime Then
            End If

        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISolidEdgeAddIn.OnDisconnection().
        ''' </summary>
        Public Sub OnDisconnection(ByVal DisconnectMode As SolidEdgeFramework.SeDisconnectMode) Implements SolidEdgeFramework.ISolidEdgeAddIn.OnDisconnection
            Select Case DisconnectMode
                Case SolidEdgeFramework.SeDisconnectMode.seDisconnectAtShutdown
                Case SolidEdgeFramework.SeDisconnectMode.seDisconnectByUser
                Case SolidEdgeFramework.SeDisconnectMode.seDisconnectExternally
            End Select

            ' Unhook all events.
            UnhookAllEvents()
        End Sub

#End Region

#Region "SolidEdgeFramework.ISEAddInEvents"

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommand event.
        ''' </summary>
        Public Sub OnCommand(ByVal CommandID As Integer) Implements SolidEdgeFramework.ISEAddInEvents.OnCommand
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommandHelp event.
        ''' </summary>
        Public Sub OnCommandHelp(ByVal hFrameWnd As Integer, ByVal HelpCommandID As Integer, ByVal CommandID As Integer) Implements SolidEdgeFramework.ISEAddInEvents.OnCommandHelp
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEAddInEvents.OnCommandUpdateUI event.
        ''' </summary>
        Public Sub OnCommandUpdateUI(ByVal CommandID As Integer, ByRef CommandFlags As Integer, <System.Runtime.InteropServices.Out()> ByRef MenuItemText As String, ByRef BitmapID As Integer) Implements SolidEdgeFramework.ISEAddInEvents.OnCommandUpdateUI
            MenuItemText = String.Empty
        End Sub

#End Region

#Region "SolidEdgeFramework.ISEApplicationEvents"

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterActiveDocumentChange event.
        ''' </summary>
        Public Sub AfterActiveDocumentChange(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterActiveDocumentChange
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterCommandRun event.
        ''' </summary>
        Public Sub AfterCommandRun(ByVal theCommandID As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.AfterCommandRun
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentOpen event.
        ''' </summary>
        Public Sub AfterDocumentOpen(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentOpen
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentPrint event.
        ''' </summary>
        Public Sub AfterDocumentPrint(ByVal theDocument As Object, ByVal hDC As Integer, ByRef ModelToDC As Double, ByRef Rect As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentPrint
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterDocumentSave event.
        ''' </summary>
        Public Sub AfterDocumentSave(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterDocumentSave
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterEnvironmentActivate event.
        ''' </summary>
        Public Sub AfterEnvironmentActivate(ByVal theEnvironment As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterEnvironmentActivate
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterNewDocumentOpen event.
        ''' </summary>
        Public Sub AfterNewDocumentOpen(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterNewDocumentOpen
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterNewWindow event.
        ''' </summary>
        Public Sub AfterNewWindow(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterNewWindow
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.AfterWindowActivate event.
        ''' </summary>
        Public Sub AfterWindowActivate(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.AfterWindowActivate
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeCommandRun event.
        ''' </summary>
        Public Sub BeforeCommandRun(ByVal theCommandID As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeCommandRun
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentClose event.
        ''' </summary>
        Public Sub BeforeDocumentClose(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentClose
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentPrint event.
        ''' </summary>
        Public Sub BeforeDocumentPrint(ByVal theDocument As Object, ByVal hDC As Integer, ByRef ModelToDC As Double, ByRef Rect As Integer) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentPrint
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentSave event.
        ''' </summary>
        Public Sub BeforeDocumentSave(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeDocumentSave
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeEnvironmentDeactivate event.
        ''' </summary>
        Public Sub BeforeEnvironmentDeactivate(ByVal theEnvironment As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeEnvironmentDeactivate
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeQuit event.
        ''' </summary>
        Public Sub BeforeQuit() Implements SolidEdgeFramework.ISEApplicationEvents.BeforeQuit
        End Sub

        ''' <summary>
        ''' Implementation of SolidEdgeFramework.ISEApplicationEvents.BeforeWindowDeactivate event.
        ''' </summary>
        Public Sub BeforeWindowDeactivate(ByVal theWindow As Object) Implements SolidEdgeFramework.ISEApplicationEvents.BeforeWindowDeactivate
        End Sub

#End Region

#Region "IConnectionPoint helpers"

        ''' <summary>
        ''' Attaches specified events to this object.
        ''' </summary>
        Private Sub HookEvents(ByVal eventSource As Object, ByVal eventGuid As Guid)
            Dim container As IConnectionPointContainer = Nothing
            Dim connectionPoint As IConnectionPoint = Nothing
            Dim cookie As Integer = 0

            container = CType(eventSource, IConnectionPointContainer)
            container.FindConnectionPoint(eventGuid, connectionPoint)

            If connectionPoint IsNot Nothing Then
                connectionPoint.Advise(Me, cookie)
                _connectionPointDictionary.Add(connectionPoint, cookie)
            End If
        End Sub

        ''' <summary>
        ''' Detaches specified events from this object.
        ''' </summary>
        Private Sub UnhookAllEvents()
            Dim enumerator As Dictionary(Of IConnectionPoint, Integer).Enumerator = _connectionPointDictionary.GetEnumerator()
            Do While enumerator.MoveNext()
                enumerator.Current.Key.Unadvise(enumerator.Current.Value)
            Loop

            _connectionPointDictionary.Clear()
        End Sub

#End Region

#Region "regasm.exe"

        ''' <summary>
        ''' Implementation of ComRegisterFunction.
        ''' </summary>
        ''' <remarks>
        ''' This method gets called when regasm.exe is executed against the assembly.
        ''' </remarks>
        <ComRegisterFunction> _
        Public Shared Sub Register(ByVal t As Type)
            Dim info = CType(AddInInfoAttribute.GetCustomAttribute(t, GetType(AddInInfoAttribute)), AddInInfoAttribute)
            Dim environments = CType(AddInEnvironmentCategoryAttribute.GetCustomAttributes(t, GetType(AddInEnvironmentCategoryAttribute)), AddInEnvironmentCategoryAttribute())
            Dim autoConnect = CType(AddInAutoConnectAttribute.GetCustomAttribute(t, GetType(AddInAutoConnectAttribute)), AddInAutoConnectAttribute)

            If info Is Nothing Then
                Throw New System.Exception("Missing AddInInfoAttribute.")
            End If
            If (environments Is Nothing) OrElse (environments.Length = 0) Then
                Throw New System.Exception("Missing AddInEnvironmentCategoryAttribute.")
            End If
            If autoConnect Is Nothing Then
                autoConnect = New AddInAutoConnectAttribute(True)
            End If

            Dim subkey As String = String.Format("CLSID\{0}", t.GUID.ToString("B"))
            Using baseKey As RegistryKey = Registry.ClassesRoot.CreateSubKey(subkey)
                subkey = String.Format("Implemented Categories\{0}", CategoryIDs.CATID_SolidEdgeAddIn)
                Using implementedCategoriesKey As RegistryKey = baseKey.CreateSubKey(subkey)
                End Using

                For Each environment In environments
                    subkey = String.Format("Environment Categories\{0}", environment.Guid.ToString("B"))
                    Using environmentCategoryKey As RegistryKey = baseKey.CreateSubKey(subkey)
                    End Using
                Next environment

                Using summaryKey As RegistryKey = baseKey.CreateSubKey("Summary")
                    summaryKey.SetValue("409", info.Summary)
                End Using

                baseKey.SetValue("AutoConnect", If(autoConnect.AutoConnect, 1, 0))
                baseKey.SetValue("409", info.Title)
            End Using
        End Sub

        ''' <summary>
        ''' Implementation of ComUnregisterFunction.
        ''' </summary>
        ''' <remarks>
        ''' This method gets called when regasm.exe is executed against the assembly.
        ''' </remarks>
        <ComUnregisterFunction> _
        Public Shared Sub Unregister(ByVal t As Type)
            Dim subkey As String = String.Format("CLSID\{0}", t.GUID.ToString("B"))
            Registry.ClassesRoot.DeleteSubKeyTree(subkey, False)
        End Sub

#End Region

#Region "Properties"

        Public ReadOnly Property Application() As SolidEdgeFramework.Application
            Get
                Return _application
            End Get
        End Property
        Public ReadOnly Property AddIn() As SolidEdgeFramework.ISEAddInEx
            Get
                Return _addInEx
            End Get
        End Property

#End Region
    End Class
End Namespace
