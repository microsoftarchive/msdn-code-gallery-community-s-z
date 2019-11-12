Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SaveAsJT
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim solidEdgeDocument As SolidEdgeFramework.SolidEdgeDocument = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to Solid Edge.
				application = SolidEdgeUtils.Connect()

				If application IsNot Nothing Then
					' Get a reference to the documents collection.
					solidEdgeDocument = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)

					Console.WriteLine("Determining document type.")

					Select Case solidEdgeDocument.Type
						Case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument, SolidEdgeFramework.DocumentTypeConstants.igPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument, SolidEdgeFramework.DocumentTypeConstants.igWeldmentAssemblyDocument, SolidEdgeFramework.DocumentTypeConstants.igWeldmentDocument
							SaveAsJT(solidEdgeDocument)
						Case Else
							Console.WriteLine("'{0}' cannot be converted to JT.", solidEdgeDocument.Type)
					End Select
				Else
					Console.WriteLine("Solid Edge is not running.")
				End If
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub


		Private Shared Sub SaveAsJT(ByVal solidEdgeDocument As SolidEdgeFramework.SolidEdgeDocument)
			' Note: Some of the parameters are obvious by their name but we need to work on getting better descriptions for some.
			Dim NewName = Path.ChangeExtension(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), solidEdgeDocument.Name), ".jt")
			Dim Include_PreciseGeom = 0
			Dim Prod_Structure_Option = 1
			Dim Export_PMI = 0
			Dim Export_CoordinateSystem = 0
			Dim Export_3DBodies = 0
			Dim NumberofLODs = 1
			Dim JTFileUnit = 0
			Dim Write_Which_Files = 1
			Dim Use_Simplified_TopAsm = 0
			Dim Use_Simplified_SubAsm = 0
			Dim Use_Simplified_Part = 0
			Dim EnableDefaultOutputPath = 0
			Dim IncludeSEProperties = 0
			Dim Export_VisiblePartsOnly = 0
			Dim Export_VisibleConstructionsOnly = 0
			Dim RemoveUnsafeCharacters = 0
			Dim ExportSEPartFileAsSingleJTFile = 0

			Console.WriteLine("Saving '{0}'", NewName)

			solidEdgeDocument.SaveAsJT(NewName, Include_PreciseGeom, Prod_Structure_Option, Export_PMI, Export_CoordinateSystem, Export_3DBodies, NumberofLODs, JTFileUnit, Write_Which_Files, Use_Simplified_TopAsm, Use_Simplified_SubAsm, Use_Simplified_Part, EnableDefaultOutputPath, IncludeSEProperties, Export_VisiblePartsOnly, Export_VisibleConstructionsOnly, RemoveUnsafeCharacters, ExportSEPartFileAsSingleJTFile)
		End Sub
	End Class
End Namespace
