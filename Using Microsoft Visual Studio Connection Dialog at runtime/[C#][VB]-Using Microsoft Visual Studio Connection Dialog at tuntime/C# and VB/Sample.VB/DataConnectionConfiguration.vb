'------------------------------------------------------------------------------ 
' <copyright company="Microsoft Corporation"> 
' Copyright (c) Microsoft Corporation. All rights reserved. 
' </copyright> 
'------------------------------------------------------------------------------ 
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml.Linq
Imports System.IO

Imports Microsoft.Data.ConnectionUI



Namespace Microsoft.Data.ConnectionUI.VB
	''' <summary> 
	''' Provide a default implementation for the storage of DataConnection Dialog UI configuration. 
	''' </summary> 
	Public Class DataConnectionConfiguration
		Implements IDataConnectionConfiguration
		Private Const configFileName As String = "DataConnection.xml"
		Private fullFilePath As String = Nothing
		Private xDoc As XDocument = Nothing

		' Available data sources: 
		Private dataSources As IDictionary(Of String, DataSource)

		' Available data providers: 
		Private dataProviders As IDictionary(Of String, DataProvider)

		''' <summary> 
		''' Constructor 
		''' </summary> 
		''' <param name="path">Configuration file path.</param> 
		Public Sub New(ByVal path As String)
			If Not [String].IsNullOrEmpty(path) Then
				fullFilePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, configFileName))
			Else
				fullFilePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, configFileName)
			End If
			If Not [String].IsNullOrEmpty(fullFilePath) AndAlso File.Exists(fullFilePath) Then
				xDoc = XDocument.Load(fullFilePath)
			Else
				xDoc = New XDocument()
				xDoc.Add(New XElement("ConnectionDialog", New XElement("DataSourceSelection")))
			End If

			Me.RootElement = xDoc.Root
		End Sub

		Private _RootElement As XElement
		Public Property RootElement() As XElement
			Get
				Return _RootElement
			End Get
			Set(ByVal value As XElement)
				_RootElement = value
			End Set
		End Property

		Public Sub LoadConfiguration(ByVal dialog As DataConnectionDialog)
			dialog.DataSources.Add(DataSource.SqlDataSource)
			dialog.DataSources.Add(DataSource.SqlFileDataSource)
			dialog.DataSources.Add(DataSource.OracleDataSource)
			dialog.DataSources.Add(DataSource.AccessDataSource)
			dialog.DataSources.Add(DataSource.OdbcDataSource)


            dialog.UnspecifiedDataSource.Providers.Add(DataProvider.SqlDataProvider)
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OracleDataProvider)
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OleDBDataProvider)
			dialog.UnspecifiedDataSource.Providers.Add(DataProvider.OdbcDataProvider)
			dialog.DataSources.Add(dialog.UnspecifiedDataSource)

			Me.dataSources = New Dictionary(Of String, DataSource)()
			Me.dataSources.Add(DataSource.SqlDataSource.Name, DataSource.SqlDataSource)
			Me.dataSources.Add(DataSource.SqlFileDataSource.Name, DataSource.SqlFileDataSource)
			Me.dataSources.Add(DataSource.OracleDataSource.Name, DataSource.OracleDataSource)
			Me.dataSources.Add(DataSource.AccessDataSource.Name, DataSource.AccessDataSource)
			Me.dataSources.Add(DataSource.OdbcDataSource.Name, DataSource.OdbcDataSource)

            Me.dataSources.Add(dialog.UnspecifiedDataSource.DisplayName, dialog.UnspecifiedDataSource)

			Me.dataProviders = New Dictionary(Of String, DataProvider)()
			Me.dataProviders.Add(DataProvider.SqlDataProvider.Name, DataProvider.SqlDataProvider)
			Me.dataProviders.Add(DataProvider.OracleDataProvider.Name, DataProvider.OracleDataProvider)
			Me.dataProviders.Add(DataProvider.OleDBDataProvider.Name, DataProvider.OleDBDataProvider)
			Me.dataProviders.Add(DataProvider.OdbcDataProvider.Name, DataProvider.OdbcDataProvider)


            Dim ds As DataSource = Nothing
			Dim dsName As String = Me.GetSelectedSource()
			If Not [String].IsNullOrEmpty(dsName) AndAlso Me.dataSources.TryGetValue(dsName, ds) Then
				dialog.SelectedDataSource = ds
			End If

			Dim dp As DataProvider = Nothing
			Dim dpName As String = Me.GetSelectedProvider()
			If Not [String].IsNullOrEmpty(dpName) AndAlso Me.dataProviders.TryGetValue(dpName, dp) Then
				dialog.SelectedDataProvider = dp
			End If
		End Sub

		Public Sub SaveConfiguration(ByVal dcd As DataConnectionDialog) 
			If dcd.SaveSelection Then
				Dim ds As DataSource = dcd.SelectedDataSource
				If ds IsNot Nothing Then
					If ds Is dcd.UnspecifiedDataSource Then
						Me.SaveSelectedSource(ds.DisplayName)
					Else
						Me.SaveSelectedSource(ds.Name)
					End If
				End If
				Dim dp As DataProvider = dcd.SelectedDataProvider
				If dp IsNot Nothing Then
					Me.SaveSelectedProvider(dp.Name)
				End If

				xDoc.Save(fullFilePath)
			End If
		End Sub

		Public Function GetSelectedSource() As String Implements IDataConnectionConfiguration.GetSelectedSource
			Try
				Dim xElem As XElement = Me.RootElement.Element("DataSourceSelection")
				Dim sourceElem As XElement = xElem.Element("SelectedSource")
				If sourceElem IsNot Nothing Then
					Return TryCast(sourceElem.Value, String)
				End If
			Catch
				Return Nothing
			End Try
			Return Nothing
		End Function

		Public Function GetSelectedProvider() As String Implements IDataConnectionConfiguration.GetSelectedProvider
			Try
				Dim xElem As XElement = Me.RootElement.Element("DataSourceSelection")
				Dim providerElem As XElement = xElem.Element("SelectedProvider")
				If providerElem IsNot Nothing Then
					Return TryCast(providerElem.Value, String)
				End If
			Catch
				Return Nothing
			End Try
			Return Nothing
		End Function

		Public Sub SaveSelectedSource(ByVal source As String) Implements IDataConnectionConfiguration.SaveSelectedSource
			If Not [String].IsNullOrEmpty(source) Then
				Try
					Dim xElem As XElement = Me.RootElement.Element("DataSourceSelection")
					Dim sourceElem As XElement = xElem.Element("SelectedSource")
					If sourceElem IsNot Nothing Then
						sourceElem.Value = source
					Else
						xElem.Add(New XElement("SelectedSource", source))
					End If
				Catch
				End Try

			End If
		End Sub

		Public Sub SaveSelectedProvider(ByVal provider As String) Implements IDataConnectionConfiguration.SaveSelectedProvider
			If Not [String].IsNullOrEmpty(provider) Then
				Try
					Dim xElem As XElement = Me.RootElement.Element("DataSourceSelection")
					Dim sourceElem As XElement = xElem.Element("SelectedProvider")
					If sourceElem IsNot Nothing Then
						sourceElem.Value = provider
					Else
						xElem.Add(New XElement("SelectedProvider", provider))
					End If
				Catch
				End Try
			End If
		End Sub
	End Class
End Namespace