Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.PropertySets
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim propertySets As SolidEdgeFramework.PropertySets = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect(True)

				' Make sure user can see the GUI.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the Documents collection.
				documents = application.Documents

				' Note: these two will throw exceptions if no document is open.
				'application.ActiveDocument
				'application.ActiveDocumentType;

				If documents.Count > 0 Then
					' Get a reference to the documents collection.
					document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)
				Else
					Throw New System.Exception("No document open.")
				End If

				propertySets = CType(document.Properties, SolidEdgeFramework.PropertySets)

				ProcessPropertySets(propertySets)

				AddCustomProperties(propertySets)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub ProcessPropertySets(ByVal propertySets As SolidEdgeFramework.PropertySets)
			Dim properties As SolidEdgeFramework.Properties = Nothing

			For i As Integer = 1 To propertySets.Count
				properties = propertySets.Item(i)

				Console.WriteLine("PropertSet '{0}'.", properties.Name)

				ProcessProperties(properties)
			Next i
		End Sub

		Private Shared Sub ProcessProperties(ByVal properties As SolidEdgeFramework.Properties)
			'SolidEdgeFramework.Property property = null;
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
            Dim objProperty As Object = Nothing ' Using dynamic so that property.Value works.

            For i As Integer = 1 To properties.Count
                Dim nativePropertyType As System.Runtime.InteropServices.VarEnum = System.Runtime.InteropServices.VarEnum.VT_EMPTY
                Dim runtimePropertyType As Type = Nothing

                Dim value As Object = Nothing

                Try
                    objProperty = properties.Item(i)
                    nativePropertyType = CType(objProperty.Type, System.Runtime.InteropServices.VarEnum)

                    ' May throw an exception...
                    value = objProperty.Value

                    If value IsNot Nothing Then
                        runtimePropertyType = value.GetType()
                    End If
                Catch ex As System.Exception
                    value = ex.Message
                End Try

                Console.WriteLine(vbTab & "{0} = '{1}' ({2} | {3}).", objProperty.Name, value, nativePropertyType, runtimePropertyType)
            Next i
		End Sub

		Private Shared Sub AddCustomProperties(ByVal propertySets As SolidEdgeFramework.PropertySets)
			Dim properties As SolidEdgeFramework.Properties = Nothing

			properties = propertySets.Item("Custom")

			Console.WriteLine("Adding custom properties.")

			properties.Add("My String", "Hello world!")
			properties.Add("My Integer", 338)
			properties.Add("My Boolean", True)
			properties.Add("My DateTime", Date.Now)
		End Sub
	End Class
End Namespace
