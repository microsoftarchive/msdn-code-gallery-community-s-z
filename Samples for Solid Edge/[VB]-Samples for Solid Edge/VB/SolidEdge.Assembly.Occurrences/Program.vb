Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Assembly.Occurrences
	''' <summary>
	''' Console application demonstrating how to work with SolidEdgeAssembly Occurrences.
	''' </summary>
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
			Dim occurrences As SolidEdgeAssembly.Occurrences = Nothing

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

				' Get a reference to the documents collection.
				documents = application.Documents

				Console.WriteLine("Creating a new assembly document.")

				' Create a new assembly document.
				assemblyDocument = CType(documents.Add("SolidEdge.AssemblyDocument"), SolidEdgeAssembly.AssemblyDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				' Get a reference to the Occurrences collection.
				occurrences = assemblyDocument.Occurrences

				AddOccurrenceByFilename(occurrences)
				AddWithTransform(occurrences)
				AddWithMatrix(occurrences)

				Console.WriteLine("Switching to ISO view.")

				ReportOccurrences(occurrences)

				' Switch to ISO view.
				application.StartCommand(CType(SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewISOView, SolidEdgeFramework.SolidEdgeCommandConstants))
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub AddOccurrenceByFilename(ByVal occurrences As SolidEdgeAssembly.Occurrences)
			Dim occurrence As SolidEdgeAssembly.Occurrence = Nothing

			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
			Dim programDirectory As New DirectoryInfo(GetSolidEdgeInstallPath())

			' Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
			Dim trainingDirectory As New DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"))

			Dim fileInfo As New FileInfo(Path.Combine(trainingDirectory.FullName, "Coffee Pot.par"))

			If fileInfo.Exists Then
				' Add the base feature at 0 (X), 0 (Y), 0 (Z).
				occurrence = occurrences.AddByFilename(fileInfo.FullName)

				Console.WriteLine("Added '{0}' using AddByFilename().", fileInfo.FullName)
			Else
				Throw New FileNotFoundException("File not found.", fileInfo.FullName)
			End If
		End Sub

		Private Shared Sub AddWithTransform(ByVal occurrences As SolidEdgeAssembly.Occurrences)
			Dim occurrence As SolidEdgeAssembly.Occurrence = Nothing

			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
			Dim programDirectory As New DirectoryInfo(GetSolidEdgeInstallPath())

			' Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
			Dim trainingDirectory As New DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"))

			Dim filenames() As String = { "strainer.asm", "handle.par"}

			' {OriginX, OriginY, OriginZ, AngleX, AngleY, AngleZ}
			' Origin in meters.
			' Angle in radians.
			Dim transforms(,) As Double = { {0, 0, 0.02062, 0, 0, 0}, {-0.06943, -0.00996, 0.05697, 0, 0, 0}}

			' Add each occurrence in array.
			For i As Integer = 0 To transforms.GetUpperBound(0)
				Dim fileInfo As New FileInfo(Path.Combine(trainingDirectory.FullName, filenames(i)))

				If fileInfo.Exists Then
					' Add the new occurrence using a transform.
					occurrence = occurrences.AddWithTransform(OccurrenceFileName:= fileInfo.FullName, OriginX:= transforms(i, 0), OriginY:= transforms(i, 1), OriginZ:= transforms(i, 2), AngleX:= transforms(i, 3), AngleY:= transforms(i, 4), AngleZ:= transforms(i, 5))

					Console.WriteLine("Added '{0}' using AddWithTransform().", fileInfo.FullName)
				Else
					Throw New FileNotFoundException("File not found.", fileInfo.FullName)
				End If
			Next i
		End Sub

		Private Shared Sub AddWithMatrix(ByVal occurrences As SolidEdgeAssembly.Occurrences)
			Dim occurrence As SolidEdgeAssembly.Occurrence = Nothing

			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
			Dim programDirectory As New DirectoryInfo(GetSolidEdgeInstallPath())

			' Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'.
			Dim trainingDirectory As New DirectoryInfo(Path.Combine(programDirectory.FullName, "Training"))

			Dim fileInfo As New FileInfo(Path.Combine(trainingDirectory.FullName, "Strap Handle.par"))

			' A single-dimension array that defines a valid transformation matrix. 
			Dim m() As Double = { 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.07913, 1.0 }

			' Convert from double[] to System.Array.
			Dim matrix As Array = m

			If fileInfo.Exists Then
				' Add the new occurrence using a matrix.
				occurrence = occurrences.AddWithMatrix(OccurrenceFileName:= fileInfo.FullName, Matrix:= matrix)

				Console.WriteLine("Added '{0}' using AddWithMatrix().", fileInfo.FullName)
			Else
				Throw New FileNotFoundException("File not found.", fileInfo.FullName)
			End If
		End Sub

		Private Shared Sub ReportOccurrences(ByVal occurrences As SolidEdgeAssembly.Occurrences)
			Dim occurrence As SolidEdgeAssembly.Occurrence = Nothing

			Console.WriteLine()

			For i As Integer = 1 To occurrences.Count
				occurrence = occurrences.Item(i)

				' Allocate a new array to hold transform.
				Dim transform(5) As Double

				' Allocate a new array to hold matrix.
				Dim matrix As Array = Array.CreateInstance(GetType(Double), 16)

				' Get the occurrence transform.
				occurrence.GetTransform(OriginX:= transform(0), OriginY:= transform(1), OriginZ:= transform(2), AngleX:= transform(3), AngleY:= transform(4), AngleZ:= transform(5))

				' Get the occurrence matrix.
				occurrence.GetMatrix(matrix)

				' Convert from System.Array to double[].  double[] is easier to work with.
				Dim m() As Double = matrix.OfType(Of Double)().ToArray()

				' Report the occurrence transform.
				Console.WriteLine("{0} transform:", occurrence.Name)
				Console.WriteLine("OriginX: {0} (meters)", transform(0))
				Console.WriteLine("OriginY: {0} (meters)", transform(1))
				Console.WriteLine("OriginZ: {0} (meters)", transform(2))
				Console.WriteLine("AngleX: {0} (radians)", transform(3))
				Console.WriteLine("AngleY: {0} (radians)", transform(4))
				Console.WriteLine("AngleZ: {0} (radians)", transform(5))
				Console.WriteLine()

				' Report the occurrence matrix.
				Console.WriteLine("{0} matrix:", occurrence.Name)
				Console.WriteLine("|{0}, {1}, {2}, {3}|", m(0), m(1), m(2), m(3))
				Console.WriteLine("|{0}, {1}, {2}, {3}|", m(4), m(5), m(6), m(7))
				Console.WriteLine("|{0}, {1}, {2}, {3}|", m(8), m(9), m(10), m(11))
				Console.WriteLine("|{0}, {1}, {2}, {3}|", m(12), m(13), m(14), m(15))

				Console.WriteLine()
			Next i
		End Sub

		Private Shared Function GetSolidEdgeInstallPath() As String
			Dim installData As New SEInstallDataLib.SEInstallData()

			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'.
			Dim programDirectory As New DirectoryInfo(installData.GetInstalledPath())

			' Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'.
			Dim installationDirectory As DirectoryInfo = programDirectory.Parent

			Return installationDirectory.FullName
		End Function
	End Class
End Namespace