'------------------------------------------------------------------------------ 
' <copyright company="Microsoft Corporation"> 
' Copyright (c) Microsoft Corporation. All rights reserved. 
' </copyright> 
'------------------------------------------------------------------------------ 

Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports Microsoft.Data.ConnectionUI

Namespace Microsoft.Data.ConnectionUI.VB
	Module Sample
		' Sample 1: 
		<STAThread()> _
		Public Sub Main(ByVal args As String())
			Dim dcd As New DataConnectionDialog()
			Dim dcs As New DataConnectionConfiguration(Nothing)
			dcs.LoadConfiguration(dcd)

			If DataConnectionDialog.Show(dcd) = DialogResult.OK Then
				' load tables 
				Using connection As New SqlConnection(dcd.ConnectionString)
					connection.Open()
					Dim cmd As New SqlCommand("SELECT * FROM sys.Tables", connection)

					Using reader As SqlDataReader = cmd.ExecuteReader()
						While reader.Read()
							Console.WriteLine(reader.HasRows)
						End While

					End Using
				End Using
			End If

			dcs.SaveConfiguration(dcd)
		End Sub

		'' Sample 2: 
		'<STAThread()> _
		'Public Sub Main(ByVal args As String())
		'	Dim dcd As New DataConnectionDialog()
		'	Dim dcs As New DataConnectionConfiguration(Nothing)
		'	dcs.LoadConfiguration(dcd)
		'	dcd.ConnectionString = "Data Source=ziz-vspro-sql05;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=Admin_007"; 


		'	If DataConnectionDialog.Show(dcd) = DialogResult.OK Then
		'		' load tables 
		'		Using connection As New SqlConnection(dcd.ConnectionString)
		'			connection.Open()
		'			Dim cmd As New SqlCommand("SELECT * FROM sys.Tables", connection)

		'			Using reader As SqlDataReader = cmd.ExecuteReader()
		'				While reader.Read()
		'					Console.WriteLine(reader.HasRows)
		'				End While

		'			End Using
		'		End Using
		'	End If

		'	dcs.SaveConfiguration(dcd)
		'End Sub
	End Module
End Namespace