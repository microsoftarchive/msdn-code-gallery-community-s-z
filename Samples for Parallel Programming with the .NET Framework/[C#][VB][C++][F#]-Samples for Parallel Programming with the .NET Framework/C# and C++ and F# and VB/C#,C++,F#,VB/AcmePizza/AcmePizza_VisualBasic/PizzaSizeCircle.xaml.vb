'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PizzaSizeCircle.xaml.vb
'
'--------------------------------------------------------------------------
Imports System.Windows.Controls

Namespace AcmePizza
    ''' <summary>
    ''' Interaction logic for PizzaSizeCircle.xaml
    ''' </summary>
    Partial Public Class PizzaSizeCircle
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Property PizzaSize() As Integer
            Get
                Return CInt(Fix(Me.GetValue(PizzaSizeProperty)))
            End Get
            Set(ByVal value As Integer)
                Me.SetValue(PizzaSizeProperty, value)

            End Set
        End Property

        Private Shared Sub PizzaSizeChangedCallBack(ByVal [property] As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
            Dim control = CType([property], PizzaSizeCircle)
            Select Case CInt(Fix(args.NewValue))
                Case 11
                    control.circle.Width = 30
                    control.circle.Height = 30
                    control.layoutRoot.Width = 30
                    control.layoutRoot.Height = 30
                    control.label.Text = "11"
                Case 13
                    control.circle.Width = 50
                    control.circle.Height = 50
                    control.layoutRoot.Width = 50
                    control.layoutRoot.Height = 50
                    control.label.Text = "13"
                Case 17
                    control.circle.Width = 75
                    control.circle.Height = 75
                    control.layoutRoot.Width = 75
                    control.layoutRoot.Height = 75
                    control.label.Text = "17"
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Sub

        Public Shared ReadOnly PizzaSizeProperty As DependencyProperty = DependencyProperty.Register("PizzaSize", GetType(Integer),
                    GetType(PizzaSizeCircle), New UIPropertyMetadata(17, New PropertyChangedCallback(AddressOf PizzaSizeChangedCallBack)))

    End Class
End Namespace
