Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives
Imports System.ComponentModel

Public Module Module1

    Public Interface ICalculator
        Function Calculate(ByVal input As String) As String
    End Interface

    Public Interface IOperation
        Function Operate(ByVal left As Integer, ByVal right As Integer) As Integer
    End Interface

    Public Interface IOperationData
        ReadOnly Property Symbol As Char
    End Interface


    <Export(GetType(IOperation))>
    <ExportMetadata("Symbol", "+"c)>
    Public Class Add
        Implements IOperation

        Public Function Operate(ByVal left As Integer, ByVal right As Integer) As Integer Implements IOperation.Operate
            Return left + right
        End Function
    End Class

    <Export(GetType(IOperation))>
    <ExportMetadata("Symbol", "-"c)>
    Public Class Subtract
        Implements IOperation

        Public Function Operate(ByVal left As Integer, ByVal right As Integer) As Integer Implements IOperation.Operate
            Return left - right
        End Function
    End Class


    <Export(GetType(ICalculator))>
    Public Class MySimpleCalculator
        Implements ICalculator

        <ImportMany()>
        Public Property operations As IEnumerable(Of Lazy(Of IOperation, IOperationData))


        Public Function Calculate(ByVal input As String) As String Implements ICalculator.Calculate
            Dim left, right As Integer
            Dim operation As Char
            Dim fn = FindFirstNonDigit(input) 'Finds the operator
            If fn < 0 Then
                Return "Could not parse command."
            End If
            operation = input(fn)
            Try
                left = Integer.Parse(input.Substring(0, fn))
                right = Integer.Parse(input.Substring(fn + 1))
            Catch ex As Exception
                Return "Could not parse command."
            End Try
            For Each i As Lazy(Of IOperation, IOperationData) In operations
                If i.Metadata.Symbol = operation Then
                    Return i.Value.Operate(left, right).ToString()
                End If
            Next
            Return "Operation not found!"
        End Function

        Private Function FindFirstNonDigit(ByVal s As String) As Integer
            For i = 0 To s.Length
                If (Not (Char.IsDigit(s(i)))) Then Return i
            Next
            Return -1
        End Function


    End Class


    Public Class Program
        Dim _container As CompositionContainer

        <Import(GetType(ICalculator))>
        Public Property calculator As ICalculator


        Public Sub New()
            'An aggregate catalog that combines multiple catalogs
            Dim catalog = New AggregateCatalog()

            'Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(New AssemblyCatalog(GetType(Program).Assembly))

            'IMPORTANT!
            'You will need to adjust this line to match your local path!
            catalog.Catalogs.Add(New DirectoryCatalog("C:\Users\SomeUser\Documents\Visual Studio 2010\Projects\SimpleCalculator2\SimpleCalculator2\Extensions"))


            'Create the CompositionContainer with the parts in the catalog
            _container = New CompositionContainer(catalog)

            'Fill the imports of this object
            Try
                _container.ComposeParts(Me)
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try
        End Sub

    End Class


    Sub Main()
        Dim p As New Program()
        Dim s As String
        Console.WriteLine("Enter Command:")
        While (True)
            s = Console.ReadLine()
            Console.WriteLine(p.calculator.Calculate(s))
        End While

    End Sub

End Module
