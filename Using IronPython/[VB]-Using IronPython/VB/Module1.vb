'Late-Binding in Visual Basic requires that Strict semantics be turned off where used.
Option Strict Off

Imports Microsoft.Scripting.Hosting
Imports IronPython.Hosting
Imports IronPython.Runtime.Types

Namespace PythonSample
    Module Module1
        Sub Main(ByVal args() As String)
            Console.WriteLine("Loading helloworld.py...")

            Dim py As ScriptRuntime = Python.CreateRuntime()

            'Late-Binding only works on objects typed as Object
            Dim helloworld As Object = py.UseFile("helloworld.py")

            Console.WriteLine("helloworld.py loaded!")

            For i = 0 To 999
                Console.WriteLine(helloworld.welcome("Employee #{0}"), i)
            Next i

            Console.ReadLine()
        End Sub
    End Module
End Namespace
