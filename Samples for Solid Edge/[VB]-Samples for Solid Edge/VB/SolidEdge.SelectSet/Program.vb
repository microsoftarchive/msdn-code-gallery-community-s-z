Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text

Namespace SolidEdge.SelectSet
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim selectSet As SolidEdgeFramework.SelectSet = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect()

				If application IsNot Nothing Then
					document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)

					selectSet = application.ActiveSelectSet

					' Report anything that is already in the SelectSet.
					ReportSelectSet(selectSet)

					' Clear the SelectSet.
					ClearSelectSet(selectSet)

					' Depending on the document type, will add items to select set.
					AddItemsToSelectSet(document)
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

		Private Shared Sub ReportSelectSet(ByVal selectSet As SolidEdgeFramework.SelectSet)
			If selectSet.Count > 0 Then
				' Loop through the items and report each one.
				For i As Integer = 1 To selectSet.Count
					Dim item As Object = selectSet.Item(i)

					' GetInteropType() is a custom method extension!
                    Dim t As Type = SolidEdgeUtils.GetInteropType(item)

					Console.WriteLine("Item[{0}] is of type '{1}'", i, t)
				Next i
			Else
				Console.WriteLine("SelectSet is empty.")
			End If
		End Sub

		Private Shared Sub ClearSelectSet(ByVal selectSet As SolidEdgeFramework.SelectSet)
			' Clear the SelectSet.
			selectSet.RemoveAll()

			Console.WriteLine("Cleared the SelectSet.")
		End Sub

		Private Shared Sub AddItemsToSelectSet(ByVal document As SolidEdgeFramework.SolidEdgeDocument)
			Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
			Dim asmRefPlanes As SolidEdgeAssembly.AsmRefPlanes = Nothing
			Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim partDocument As SolidEdgePart.PartDocument = Nothing
			Dim sheetMetalDocument As SolidEdgePart.SheetMetalDocument = Nothing
			Dim edgeBarFeatures As SolidEdgePart.EdgebarFeatures = Nothing

			Select Case document.Type
				Case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument
					assemblyDocument = CType(document, SolidEdgeAssembly.AssemblyDocument)
					asmRefPlanes = assemblyDocument.AsmRefPlanes

					For i As Integer = 1 To asmRefPlanes.Count
						assemblyDocument.SelectSet.Add(asmRefPlanes.Item(i))
					Next i
				Case SolidEdgeFramework.DocumentTypeConstants.igDraftDocument
					draftDocument = CType(document, SolidEdgeDraft.DraftDocument)
					sheet = draftDocument.ActiveSheet
					drawingViews = sheet.DrawingViews

					For i As Integer = 1 To drawingViews.Count
						draftDocument.SelectSet.Add(drawingViews.Item(i))
					Next i

				Case SolidEdgeFramework.DocumentTypeConstants.igPartDocument
					partDocument = CType(document, SolidEdgePart.PartDocument)
					edgeBarFeatures = partDocument.DesignEdgebarFeatures

					For i As Integer = 1 To edgeBarFeatures.Count
						partDocument.SelectSet.Add(edgeBarFeatures.Item(i))
					Next i

				Case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument
					sheetMetalDocument = CType(document, SolidEdgePart.SheetMetalDocument)
					edgeBarFeatures = sheetMetalDocument.DesignEdgebarFeatures

					For i As Integer = 1 To edgeBarFeatures.Count
						partDocument.SelectSet.Add(edgeBarFeatures.Item(i))
					Next i
			End Select
		End Sub

		'static Type GetTypeForComObject(object o)
		'{
		'    if (o == null) throw new ArgumentNullException();

		'    if (Marshal.IsComObject(o))
		'    {
		'        IDispatch dispatch = o as IDispatch;
		'        if (dispatch != null)
		'        {
		'            ITypeLib typeLib = null;
		'            ITypeInfo typeInfo = dispatch.GetTypeInfo(0, 0);
		'            int index = 0;
		'            typeInfo.GetContainingTypeLib(out typeLib, out index);

		'            string typeLibName = Marshal.GetTypeLibName(typeLib);
		'            string typeInfoName = Marshal.GetTypeInfoName(typeInfo);

		'            string typeFullName = String.Format("{0}.{1}", typeLibName, typeInfoName);

		'            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		'            Assembly assembly =  assemblies.FirstOrDefault(x => x.GetType(typeFullName) != null);
		'            if (assembly != null)
		'            {
		'                return assembly.GetType(typeFullName);
		'            }
		'        }
		'    }

		'    return o.GetType();
		'}
	End Class
End Namespace
