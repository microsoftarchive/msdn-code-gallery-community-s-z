' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System.Diagnostics
Public Class ThisWorkbook

    Private customerOrdersControl As CustomersOrdersControl
    Private currentCompanyDataMember As CompanyData
    Private customersBindingSourceMember As BindingSource
    Private customerOrdersBindingSourceMember As BindingSource
    Private orderDetailsBindingSourceMember As BindingSource
    Private statusBindingSourceMember As BindingSource

    Private Sub ThisWorkbook_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        LoadCompanyData()
        Me.customerOrdersControl = New CustomersOrdersControl()
        Me.ActionsPane.Controls.Add(customerOrdersControl)
    End Sub

    Private Sub ThisWorkbook_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

    Friend ReadOnly Property CurrentCompanyData() As CompanyData
        Get
            Debug.Assert(Me.currentCompanyDataMember IsNot Nothing)
            Return currentCompanyDataMember
        End Get
    End Property

    Friend ReadOnly Property CustomersBindingSource() As BindingSource
        Get
            If (Me.customersBindingSourceMember Is Nothing) Then
                Me.customersBindingSourceMember = New BindingSource()
                Me.customersBindingSourceMember.DataSource = Me.CurrentCompanyData
                Me.customersBindingSourceMember.DataMember = "Customers"
            End If

            Return Me.customersBindingSourceMember
        End Get
    End Property

    Friend ReadOnly Property CustomerOrdersBindingSource() As BindingSource
        Get
            If (Me.customerOrdersBindingSourceMember Is Nothing) Then
                Me.customerOrdersBindingSourceMember = New BindingSource()
                Me.customerOrdersBindingSourceMember.DataSource = Me.CustomersBindingSource
                Me.customerOrdersBindingSourceMember.DataMember = "FK_Customers_Orders"
                Me.customerOrdersBindingSourceMember.Filter = "StatusID <> 0"
            End If

            Return Me.customerOrdersBindingSourceMember
        End Get
    End Property

    Friend ReadOnly Property OrderDetailsBindingSource() As BindingSource
        Get
            If (Me.orderDetailsBindingSourceMember Is Nothing) Then
                Me.orderDetailsBindingSourceMember = New BindingSource()
                Me.orderDetailsBindingSourceMember.DataSource = Me.CustomerOrdersBindingSource
                Me.orderDetailsBindingSourceMember.DataMember = "FK_Orders_OrderDetails"
            End If

            Return Me.orderDetailsBindingSourceMember
        End Get
    End Property

    Friend ReadOnly Property StatusBindingSource() As BindingSource
        Get
            If (Me.statusBindingSourceMember Is Nothing) Then
                Me.statusBindingSourceMember = New BindingSource()
                Me.statusBindingSourceMember.DataSource = Me.CustomerOrdersBindingSource
                Me.statusBindingSourceMember.DataMember = "Orders_Status"
            End If

            Return Me.statusBindingSourceMember
        End Get
    End Property


    Private Sub LoadCompanyData()
        Debug.Assert(Me.currentCompanyDataMember Is Nothing)
        Me.currentCompanyDataMember = New CompanyData()
        Me.currentCompanyDataMember.DataSetName = "CompanyData"
        Me.currentCompanyDataMember.Locale = New System.Globalization.CultureInfo("en-US")
        Me.currentCompanyDataMember.RemotingFormat = System.Data.SerializationFormat.Xml

        Dim fileLocation As String = System.IO.Path.Combine(Me.Path, "data.xml")
        Debug.Assert(System.IO.File.Exists(fileLocation), _
            String.Format("Sample data file {0} does not exist.", fileLocation))

        Me.currentCompanyDataMember.ReadXml(fileLocation)
        Me.CurrentCompanyData.AcceptChanges()
    End Sub
            
End Class
